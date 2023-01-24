namespace MauiEdit.ViewModels;

public class ModalViewResultEventArgs : EventArgs
{
    public ModalViewResultEventArgs(string result)
    {
        Result = result;
    }

    public string Result { get; }
}
