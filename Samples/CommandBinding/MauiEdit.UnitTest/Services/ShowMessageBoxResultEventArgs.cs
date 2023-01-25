namespace MauiEdit.UnitTest;

public class ShowMessageBoxResultEventArgs : EventArgs
{
    public ShowMessageBoxResultEventArgs(string? resultButtonText = null)
    {
        ResultButtonText = resultButtonText;
    }

    public string? ResultButtonText { get; set; }
}
