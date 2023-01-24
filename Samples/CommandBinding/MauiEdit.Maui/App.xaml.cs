using MauiEdit.Services;
using MauiEdit.ViewModels;

namespace MauiEdit;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
		InitializeComponent();

        var dialogService = serviceProvider.GetRequiredService<IDialogService>();

        MainPage = new AppShell();
        dialogService.SetMarshallingContext(MainPage);

		MainPage.BindingContext = new MainFormController(serviceProvider);
	}
}
