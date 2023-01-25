using System.Diagnostics;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using MauiEdit.Services;
using MauiEdit.Services.Extension;

namespace MauiEdit.ViewModels;

// Class implements INotifyPropertyChanged and simplifies it correct
// handling over BindableBase by using [CallingMemberName]
public partial class MainFormController : ViewController
{
    public const string YesButtonText = "Yes";
    public const string NoButtonText = "No";

    [RelayCommand(CanExecute = nameof(CanExecuteContentDependingCommands))]
    private void InsertDemoText()
        => TextDocument = GetTestText();

    // Note: Relay Commands can be implemented synchronously and asynchronously.
    // Especially in MAUI apps, a UI dependent method should never block UI.
    // In WinForms, it's not that big a deal, but running tasks asynchronously
    // is also making WinForms apps more responsive - which never hurts!
    [RelayCommand(CanExecute = nameof(CanExecuteContentDependingCommands))]
    private async Task ToUpperAsync()
    {
        if (string.IsNullOrEmpty(TextDocument))
        {
            return;
        }

        string tempText = null!;
        var savedSelectionIndex = SelectionIndex;

        // This has more of a demo character than it is a real necessity in this context:
        // We're running a CPU-bound task here to guarantee a fluent UI. To that end,
        // we're awaiting the task which we started here. Be careful, though, for WinForms
        // if you spin of CPU-bound tasks in TerminalServer or Desktop-virtualization scenarios.
        // You could quickly exhaust processor resources, and that would be counter intuitive
        // in terms of performance.
        await Task.Run(() =>
        {
            var upperText = TextDocument[SelectionIndex..(SelectionIndex + SelectionLength)].ToUpper();

            tempText = string.Concat(
                TextDocument[..SelectionIndex].AsSpan(),
                upperText.AsSpan(),
                TextDocument[(SelectionIndex + SelectionLength)..].AsSpan());
        });

        // When you are modifying the UI: Make sure you do it on the UI thread!
        // While we generated tempText on a worker thread, the actual assignment
        // (which triggers the updating through data binding) is happening back on
        // the UI thread. You would get cross-thread-exceptions otherwise. This is
        // true for all the UI stacks.
        TextDocument = tempText;                // This is the new "uppered" text.
        SelectionIndex = savedSelectionIndex;   // We're restoring the cursor position.
    }

    [RelayCommand(CanExecute = nameof(CanExecuteContentDependingCommands))]
    private async Task NewDocumentAsync()
    {
        // So, this is how we control the UI via a Controller or ViewModel.
        // We get the required Service over the ServiceProvider, 
        // which the Controller/ViewModels got via Dependency Injection.
        // Dependency Injection means, _depending_ on what UI-Stack (or even inside a Unit Test)
        // we're actually running, the dialogService will do different things:

        // * On WinForms it shows a WinForms MessageBox.
        // * On MAUI, it displays an alert.
        // * In the context of a unit test, it doesn't show anything: the unit test,
        //   just pretends, the user had clicked the result button.
        var dialogService = ServiceProvider.GetRequiredService<IDialogService>();

        // Now we use this DialogService to remote-control the UI completely
        // _and_ independent of the actual UI technology.
        var buttonString = await dialogService.ShowMessageBoxAsync(
            title: "New Document",
            heading: "Do you want to create a new Document?",
            message: "You are about to create a new Document. The old document will be erased, changes you made will be lost.",
            buttons: new[] { YesButtonText, NoButtonText });

        if (buttonString == YesButtonText)
        {
            TextDocument = string.Empty;
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteContentDependingCommands))]
    private async Task RewrapAsync()
    {
        if (string.IsNullOrEmpty(TextDocument))
            return;

        var cursorPos = SelectionIndex;

        TextDocument = await Task.Run<string>(() =>
        {
            var firstPartEndPos = CharPosFromLineNumber(SelectionLines.StartLine - 1);
            var wrapPartEndPos = CharPosFromLineNumber(SelectionLines.EndLine);
            var lastPartEndPos = TextDocument.Length;

            string firstPart = TextDocument[0..(firstPartEndPos == -1 ? 0 : firstPartEndPos)];
            string wrapPart = TextDocument[(firstPartEndPos == -1 ? 0 : firstPartEndPos)..wrapPartEndPos];
            string lastPart = TextDocument[(wrapPartEndPos == lastPartEndPos ? lastPartEndPos : wrapPartEndPos)..lastPartEndPos];

            // Wrapping just the wrapPart.
            StringBuilder wrappedPart = new(wrapPart.Length);
            wrapPart = wrapPart.Replace(CarriageReturn, " ").Replace("  ", " ");

            int i = 0;
            int lineCharCount = 0;
            int lastPotentialWrapPos = 0;

            while (i < wrapPart.Length)
            {
                wrappedPart.Append(wrapPart[i]);

                if (wrapPart[i] == ' ' || wrapPart[i] == '-')
                {
                    lastPotentialWrapPos = i;
                }

                if (lineCharCount++ > CharCountWrapThreshold)
                {
                    wrappedPart[lastPotentialWrapPos] = '\r';
                    lineCharCount = 0;
                }

                i++;
            }

            if (CarriageReturn != "\r")
            {
                wrappedPart = wrappedPart.Replace("\r", CarriageReturn);
            }

            return ($"{firstPart}{wrappedPart}{CarriageReturn}{lastPart}");
        });

        SelectionIndex = cursorPos;
    }

    private bool CanExecuteContentDependingCommands()
        => TextDocument?.Length > 0;

    [RelayCommand()]
    private async Task ShowToolsOptionsAsync()
    {
        var dialogService = ServiceProvider.GetRequiredService<IDialogService>();
        var optionsFormController = new OptionsFormController(ServiceProvider);

        // Set this to something meaningful.
        optionsFormController.DateOption = DateTime.Now.Date;
        
        string dialogResult = await dialogService.ShowModalAsync(optionsFormController);
        
        Debug.Print($"Dialog result: {dialogResult}");
        Debug.Print($"Dialog content: {optionsFormController}");
    }
}
