namespace MauiEdit.Services;

internal class WinFormsAsyncHelper
{
    private readonly Control _marshallingControl;
    private static WinFormsAsyncHelper? s_instance;

    private WinFormsAsyncHelper(Control marshallingControl)
    {
        _marshallingControl = marshallingControl;
    }

    public static WinFormsAsyncHelper GetInstance(Control marshallingControl)
        => s_instance ??= new WinFormsAsyncHelper(marshallingControl);

    public async Task<T?> InvokeAsync<T>(Func<T> function)
    {
        TaskCompletionSource<bool> taskCompletionSource = new();
        IAsyncResult? asyncResult = _marshallingControl.BeginInvoke(function);

        var registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(
               asyncResult.AsyncWaitHandle,
               new WaitOrTimerCallback(InvokeAsyncCallBack),
               taskCompletionSource,
               millisecondsTimeOutInterval: -1,
               executeOnlyOnce: true);

        await taskCompletionSource.Task;

        object? returnObject = _marshallingControl.EndInvoke(asyncResult);
        return (T?)returnObject;
    }

    private static void InvokeAsyncCallBack(object? state, bool timeOut)
    {
        try
        {
            if (state is TaskCompletionSource<bool> source)
            {
                source.TrySetResult(timeOut);
            }
        }
        catch (Exception ex)
        {
            if (state is TaskCompletionSource<bool> source)
            {
                source.TrySetException(ex);
            }
        }
    }
}
