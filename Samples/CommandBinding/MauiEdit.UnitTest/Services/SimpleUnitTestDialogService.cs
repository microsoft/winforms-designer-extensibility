using MauiEdit.Services;
using MauiEdit.ViewModels;

namespace MauiEdit.UnitTest;

public class SimpleUnitTestDialogService : IDialogService
{
    public event EventHandler<ShowMessageBoxResultEventArgs>? ShowMessageBoxRequested;

    public async Task<string> ShowModalAsync(ModalViewController registeredController)
    {
        ShowMessageBoxResultEventArgs eArgs = new();
        ShowMessageBoxRequested?.Invoke(this, eArgs);

        return await Task.FromResult(eArgs.ResultButtonText ?? "Cancel");
    }

    public void SetMarshallingContext(object syncContext)
    {
        throw new NotImplementedException();
    }

    public async Task<string> ShowMessageBoxAsync(
        string title, string heading, string message, params string[] buttons)
    {
        ShowMessageBoxResultEventArgs eArgs = new();
        ShowMessageBoxRequested?.Invoke(this, eArgs);

        if (eArgs.ResultButtonText is null)
        {
            throw new NullReferenceException("MessageBox test result can't be null.");
        }

        return await Task.FromResult(eArgs.ResultButtonText ?? "Cancel");
    }
}
