using MauiEdit.Services;
using MauiEdit.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiEdit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // We pass the dialog service to the service provider, so we can use it in the view models.
        var mauiDialogService = new MauiDialogService();
        builder.Services.AddSingleton(typeof(IDialogService), mauiDialogService);

        mauiDialogService
        .RegisterUIController(
                uiController: typeof(OptionsFormController),
                viewAsForm: typeof(OptionsPage));

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
