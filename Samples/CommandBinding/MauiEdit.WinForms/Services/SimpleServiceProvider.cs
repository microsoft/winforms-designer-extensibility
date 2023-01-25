using MauiEdit.Services;

namespace WinFormsCommandBindingDemo
{
    static partial class Program
    {
        public class SimpleServiceProvider : IServiceProvider
        {
            private static IServiceProvider? s_instance;

            private IDialogService? _winFormsDialogService;

            public object GetService(Type serviceType)
                => serviceType switch
                {
                    Type requestedType when typeof(IDialogService).IsAssignableFrom(requestedType)
                        => _winFormsDialogService ??= new WinFormsDialogService(),

                    Type requestedType when typeof(WinFormsDialogService).IsAssignableFrom(requestedType)
                        => _winFormsDialogService ??= new WinFormsDialogService(),

                    _ => throw new NotImplementedException($"Requested service '{serviceType}' is not supported.")
                };

            public static IServiceProvider GetInstance()
                => s_instance ??= new SimpleServiceProvider();
        }
    }
}
