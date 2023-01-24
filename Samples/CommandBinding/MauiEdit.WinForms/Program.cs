using MauiEdit.Services;
using MauiEdit.Services.Extension;
using MauiEdit.ViewModels;

namespace WinFormsCommandBindingDemo;

static partial class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // // Comment this out, to enable the simple WinForms binding demo.
        // Application.Run(new SimpleTestForm());
        // return;
        
        var mainForm = new MainForm();

        // We need a marshalling control.
        WinFormsDialogService.RegisterWinFormsAsyncHelper(WinFormsAsyncHelper.GetInstance(mainForm));

        var serviceProvider=SimpleServiceProvider.GetInstance();
        
        serviceProvider
            .GetRequiredService<WinFormsDialogService>()
            .RegisterUIController(
                uiController: typeof(OptionsFormController), 
                viewAsForm: typeof(OptionsForm));

        Application.Run(mainForm);
    }
}
