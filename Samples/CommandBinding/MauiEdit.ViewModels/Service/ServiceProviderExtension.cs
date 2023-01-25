namespace MauiEdit.Services.Extension;

public static class ServiceProviderExtension
{
    static public T GetRequiredService<T>(this IServiceProvider serviceProvider)
    {
        if (serviceProvider.GetService(typeof(T)) is T service)
        {
            return service;
        }
        
        throw new InvalidOperationException($"Service {typeof(T).Name} not found.");
    }
}
