using MauiEdit.ViewModels;

namespace MauiEdit.Services;

// This is just an example how to implement the communication between the
// FormsController and the View (the Form).
public interface IDialogService
{
    void SetMarshallingContext(object syncContext);
    Task<string> ShowModalAsync(ModalViewController registeredController);
    Task<string> ShowMessageBoxAsync(string title, string heading, string message, params string[] buttons);
}
