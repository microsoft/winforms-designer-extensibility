using System.ComponentModel;
using System.Diagnostics;

namespace WinFormsCommandBindingDemo;

/// <summary>
///  TextBox based Editor control, which provides a CursorPosition property.
///  (This property is bindable and works like the pendant in MAUI.)
/// </summary>
internal class EditorControl : TextBox
{
    // We need to tune SelectionLength a bit, so it becomes bindable.
    public event EventHandler? SelectionLengthChanged;

    // We need to provide a CursorPosition property, so we can bind against it.
    public event EventHandler? CursorPositionChanged;

    private const int EM_LINEFROMCHAR= 0xC9;

    private int _cursorPosition;

    public EditorControl() : base()
    {
    }

    /// <summary>
    ///  Provides the Cursor position in absolute characters. 
    ///  This property is bindable, but effectively read-only.
    /// </summary>
    [Bindable(BindableSupport.Yes)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int CursorPosition
    {
        get => _cursorPosition;

        // We have a setter alright, but it never updates SelectionIndex.
        // We need it to be here, so it can be bound at all to begin with,
        // but it has only "informational" character. (In contrast to MAUI, btw.)
        set
        {
            if (value == _cursorPosition)
            {
                return;
            }

            Debug.Print($"--> Inside CursorPosition Setter: Value:{value}");
            _cursorPosition = value;
            OnCursorPositionChanged(EventArgs.Empty);
        }
    }

    [Bindable(BindableSupport.Yes)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public new int SelectionLength
    {
        get => base.SelectionLength;

        // We emulate OneWayToSource binding by ignoring the setter.
        // But to trigger the value change, we call OnSelectionLengthChanged
        // from UpdateSelectionInfo.
        set { }
    }

    /// <summary>
    ///  Raises the SelectionLengthChanged Event and makes SelectionLength bindable.
    /// </summary>
    protected virtual void OnSelectionLengthChanged(EventArgs e)
        => SelectionLengthChanged?.Invoke(this, e);

    
    /// <summary>
    ///  Raises the CursorPositionChanged event and makes CursorPosition bindable.
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnCursorPositionChanged(EventArgs e)
        => CursorPositionChanged?.Invoke(this, e);

    // We want to listen to the EM_LINEFORMCHAR message. When it occurs, we know, the Selection has been
    // changed in a way. Then we queue a call to update CursorPosition and notify both for CursorPosition
    // and SelectionLength.
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // When EM_LINEFROMCHAR has been called, something changed with the Selection...
        if (m.Msg == EM_LINEFROMCHAR)
        {
            // ...in this case, we call BeginInvoke to queue the call to the Action
            // we pass in the MessageQueue. This way, we ensure to complete the processing
            // of the current batch of messages for whatever happens in this control, and
            // only then the action delegate gets called. If we execute the action delegate
            // immediately, we break the Selection procedure of the TextBox.
            BeginInvoke(() =>
            {
                try
                {
                    OnSelectionLengthChanged(EventArgs.Empty);
                    CursorPosition = SelectionStart;
                }
                catch (Exception)
                {
                }
            });
        }
    }
}
