using MauiEdit.Services;

namespace MauiEdit.UnitTest;

public class SimpleTestServiceProvider : IServiceProvider
{
    private static IServiceProvider? s_instance;

    private IDialogService? _unitTestDialogService;

    public object GetService(Type serviceType)
        => serviceType switch
        {
            Type requestedType when typeof(IDialogService).IsAssignableFrom(requestedType)
                => _unitTestDialogService ??= new SimpleUnitTestDialogService(),

            Type requestedType when typeof(SimpleUnitTestDialogService).IsAssignableFrom(requestedType)
                => _unitTestDialogService ??= new SimpleUnitTestDialogService(),

            _ => throw new NotImplementedException($"Requested service '{serviceType}' is not supported.")
        };

    public static IServiceProvider GetInstance()
        => s_instance ??= new SimpleTestServiceProvider();
}
