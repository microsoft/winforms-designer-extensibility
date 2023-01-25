using MauiEdit.ViewModels;

#nullable enable

namespace MauiEdit.Services;

internal class MauiDialogService : IDialogService
{
    private Page? _marshallingContextAsPage;
    private readonly Dictionary<Type, Type> _controllerFormTypeLookup = new();

    public async Task<string> ShowModalAsync(ModalViewController registeredController)
    {
        TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();

        // We need the controller (ViewModel) which is assigned to the View (Page) in any case.
        ArgumentNullException.ThrowIfNull(registeredController);

        // We need to be notified when the View (Page) is closed.
        registeredController.Closed += ModalViewClosedHandler;

        try
        {
            // We need a page to navigate the modal view stack.
            if (_marshallingContextAsPage is null)
            {
                throw new NullReferenceException($"The marshalling context (a Maui Page) has not been setup.\n" +
                    $"Call '{nameof(SetMarshallingContext)}' on '{nameof(IDialogService)}' to setup the page.");
            }

            if (_controllerFormTypeLookup.TryGetValue(registeredController.GetType(), out var viewType))
            {
                if (Activator.CreateInstance(viewType) is Page view)
                {
                    // Important: OKCommand and CancelCommand MUST be bound inside the (modal) view.
                    // The ModalViewController class is providing those commands.
                    view.BindingContext = registeredController;

                    await _marshallingContextAsPage.Navigation.PushModalAsync(view);

                    // Wait for the modal view to be closed. That happens below in ModalViewClosedHandler.
                    return await taskCompletionSource.Task;
                }
            }

            throw new Exception($"Could not create the view of type {viewType}.");
        }
        finally
        {
            registeredController.Closed -= ModalViewClosedHandler;
        }

        async void ModalViewClosedHandler(object? s, ModalViewResultEventArgs e)
        {
            // On OK or Cancel, we need to pop the modal view stack.
            await _marshallingContextAsPage!.Navigation.PopModalAsync();

            // And since we have the result from the respective commands, we can set the result based on that.
            taskCompletionSource.SetResult(e.Result);
        }
    }

    public void SetMarshallingContext(object syncContext)
    {
        _marshallingContextAsPage = syncContext as Page;
    }

    public async Task<string> ShowMessageBoxAsync(string title, string heading, string message, params string[] buttons)
    {
        if (_marshallingContextAsPage is not null)
        {
            return await _marshallingContextAsPage.DisplayAlert(title, message, buttons[1], buttons[0])
                ? buttons[1]
                : buttons[0];
        }

        throw new NullReferenceException($"The marshalling context (a Maui Page) has not been setup.\n" +
            $"Call '{nameof(SetMarshallingContext)}' on '{nameof(IDialogService)}' to setup the page.");
    }

    public void RegisterUIController(Type uiController, Type viewAsForm)
    {
        _controllerFormTypeLookup.Add(uiController, viewAsForm);
    }
}
