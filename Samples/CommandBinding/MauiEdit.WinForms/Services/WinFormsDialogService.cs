using MauiEdit.ViewModels;

namespace MauiEdit.Services;

internal class WinFormsDialogService : IDialogService
{
    private readonly Dictionary<Type, Type> _controllerFormTypeLookup = new();

    private static readonly SynchronizationContext? s_winFormsSyncContext 
        = SynchronizationContext.Current;

    private static WinFormsAsyncHelper? s_asyncHelper;

    public static void RegisterWinFormsAsyncHelper(WinFormsAsyncHelper asyncHelper)
    {
        if (asyncHelper is null)
        {
            throw new ArgumentNullException(nameof(asyncHelper));
        }

        s_asyncHelper = asyncHelper;
    }

    public void RegisterUIController(Type uiController, Type viewAsForm)
    {
        if (s_winFormsSyncContext is null)
        {
            throw new Exception("Fail to retrieve a WinForms synchronization context, " +
                "which is needed to run asynchronous Dialog Service calls.");
        }

        _controllerFormTypeLookup.Add(uiController, viewAsForm);
    }

    public async Task<string> ShowModalAsync(ModalViewController registeredController)
    {
        ArgumentNullException.ThrowIfNull(registeredController);

        if (_controllerFormTypeLookup.TryGetValue(registeredController.GetType(), out var viewType))
        {
            if (Activator.CreateInstance(viewType) is Form view)
            {
                view.DataContext = registeredController;

                // Since the Buttons are supposed to be command-bound
                // the ViewModel should know the dialog result via binding.
                DialogResult dialogResult = await s_asyncHelper!.InvokeAsync(
                    () => view.ShowDialog());

                string returnValue = dialogResult switch
                {
                    DialogResult.OK => "OK",
                    DialogResult.Cancel => "Cancel",
                    _ => throw new Exception($"Unknown dialog result: {dialogResult}"),
                };

                return returnValue;
            }

            throw new Exception($"Could not create the view of type {viewType}.");
        }

        throw new Exception($"Could not find a view for controller of type {registeredController.GetType()}.");
    }

    public async Task<string> ShowMessageBoxAsync(string title, string heading, string message, params string[] buttons)
    {
        var mainDialogPage = new TaskDialogPage()
        {
            Caption = title,
            Heading = heading,
            Text = message,

            Icon = TaskDialogIcon.Information
        };

        var taskDialogButtons = new TaskDialogButtonCollection();

        foreach (var buttonString in buttons)
        {
            // Each of the buttons will be enabled and close the MessageBox.
            taskDialogButtons.Add(
                new TaskDialogButton(
                    buttonString,
                    enabled: true,
                    allowCloseDialog: true));
        }

        mainDialogPage.Buttons = taskDialogButtons;

        TaskDialogButton? result;
        result = await s_asyncHelper!.InvokeAsync(() => TaskDialog.ShowDialog(mainDialogPage));

        return $"{result}";
    }

    public void SetMarshallingContext(object syncContext)
    {
        throw new NotImplementedException();
    }
}
