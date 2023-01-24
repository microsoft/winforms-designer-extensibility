using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiEdit.ViewModels;

/// <summary>
///  Main ViewModel for the WinForms/MAUI-Editor sample app. Encapsulated the full logic of the app.
/// </summary>
public partial class MainFormController : ViewController
{
    // Holds the whole editor document.
    private string? _textDocument;

    // Backing field to iterate line-wise through the whole document.
    private ReadOnlyMemory<char>[] _lines = Array.Empty<ReadOnlyMemory<char>>();

    /// <summary>
    ///  Gets the selection start- and end line based on SelectionIndex and SelectionLength.
    ///  Annotated with <see cref="ObservablePropertyAttribute"/>, so the property is automatically code-generated.
    /// </summary>
    [ObservableProperty]
    private (int StartLine, int EndLine) _selectionLines;

    /// <summary>
    ///  Current length of the selection.
    /// </summary>
    [ObservableProperty]
    private int _selectionLength;

    /// <summary>
    ///  Column where the cursor is located.
    /// </summary>
    [ObservableProperty]
    private int _selectionColumn;

    /// <summary>
    ///  Row where the cursor is located.
    /// </summary>
    [ObservableProperty]
    private int _selectionRow;

    /// <summary>
    ///  The index of the first selected character 
    ///  (or the current cursor position index in to the editor's doc).
    /// </summary>
    [ObservableProperty]
    private int _selectionIndex;

    /// <summary>
    ///  Character count threshold until we wrap to the next line when calling the wrap command.
    /// </summary>
    [ObservableProperty]
    private int _charCountWrapThreshold = 60;

    /// <summary>
    ///  Creates an instance of this class.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public MainFormController(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        // The initial sample text:
        TextDocument = $"""
                This is a test document.
                It doesn't contain a lot of information.
                But it contains enough, to test this app.

                Just a few lines of text are sufficient for that.

                Today is {DateTime.Now:dddd, MMMM dd. yyyy}. It is {DateTime.Now: hh:mm tt}.

                The end.
                """;
    }

    /// <summary>
    ///  Provides the Document for the Editor.
    /// </summary>
    public string? TextDocument
    {
        get => _textDocument;

        set
        {
            var wasEmpty = string.IsNullOrEmpty(_textDocument);

            if (SetProperty(ref _textDocument, value))
            {
                _lines = GetLinesFromDocument();

                if (wasEmpty ^ string.IsNullOrEmpty(_textDocument))
                {
                    NewDocumentCommand.NotifyCanExecuteChanged();
                    ToUpperCommand.NotifyCanExecuteChanged();
                }
            }
        }
    }

    // The CarriageReturn string we detect.
    private string CarriageReturn
        => GetCarriageReturnStringBasedOnDocument() ?? "\r\n";

    /// <summary>
    ///  Returns a list of lines of the document.
    /// </summary>
    public ReadOnlyMemory<char>[] Lines
        => _lines;

    // This is an example how to implement the On...Changed method for a property,
    // which has been automatically generated. The MVVM Community Toolkit provides 
    // partial On...Methods methods for generated properties which can be amended like this:
    partial void OnSelectionLinesChanged((int StartLine, int EndLine) value)
        => Debug.Print($"SelectionLine: {_selectionLines}");

    partial void OnSelectionLengthChanged(int value)
        => UpdateSelectionInfo();

    partial void OnSelectionIndexChanged(int value)
        => UpdateSelectionInfo();

    /// <summary>
    ///  Triggers calculation of SelectionRow, SelectionColumn and SelectionLines.
    /// </summary>
    private void UpdateSelectionInfo()
    {
        (SelectionRow, SelectionColumn) = GetRowAndColumnFromPosition(_selectionIndex);

        SelectionLines = (
            SelectionRow,
            GetRowAndColumnFromPosition(_selectionIndex + _selectionLength).Row);
    }

    // Finds out, how the line breaks are coded, which unfortunately
    // is different for the respected textbox controls on different platforms.
    //
    // This could be done more reliably, by having a dedicated
    // Property, which determines the platform's behavior directly
    // through a platform-depending binding.
    // But this here works too.
    private string? GetCarriageReturnStringBasedOnDocument()
    {
        if (TextDocument is null)
        {
            return null;
        }

        if (TextDocument?.IndexOf("\r\n") > -1)
        {
            // Android & WinForms TextBox.
            return "\r\n";
        }
        else if (TextDocument?.IndexOf("\n\r") > -1)
        {
            // We shouldn't have this.
            return "\n\r";
        }
        else if (TextDocument?.IndexOf("\r") > -1)
        {
            // WinUI TextBox.
            return "\r";
        }

        // We don't have CrLf yet.
        else
        {
            return null;
        }
    }

    // Calculates the line start- and endings.
    private ReadOnlyMemory<char>[] GetLinesFromDocument()
    {
        if (string.IsNullOrEmpty(TextDocument))
        {
            return Array.Empty<ReadOnlyMemory<char>>();
        }

        List<ReadOnlyMemory<char>> lines = new();

        int pos = 0;
        int previousPos = 0;

        for (; ; )
        {
            pos = TextDocument.IndexOf(CarriageReturn, pos);

            if (pos == -1 || previousPos > pos)
                break;

            lines.Add(TextDocument.AsMemory()[previousPos..pos]);
            pos += CarriageReturn.Length;
            previousPos = pos;
        }

        lines.Add(TextDocument.AsMemory()[previousPos..]);
        return lines.ToArray();
    }

    // Calculates the character index in to the document from a line number.
    private int CharPosFromLineNumber(int lineNumber)
    {
        if (lineNumber > Lines.Length)
        {
            lineNumber = Lines.Length;
        }

        int charPos = 0;

        for (int i = 0; i < lineNumber; i++)
        {
            charPos += Lines[i].Length + CarriageReturn.Length;
        }

        return charPos;
    }

    // Calculates the Line and the Column based on the character index into the doc.
    private (int Row, int Column) GetRowAndColumnFromPosition(int position)
    {
        if (string.IsNullOrEmpty(TextDocument))
        {
            return (1, 1);
        }

        int charCount = 0;
        int lineCount = 0;

        while (lineCount < Lines.Length && charCount + Lines[lineCount].Length < position)
        {
            charCount += Lines[lineCount].Length + CarriageReturn.Length;
            lineCount++;
        }

        return (lineCount + 1, (position - charCount) + 1);
    }
}
