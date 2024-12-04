using System.Diagnostics.CodeAnalysis;

namespace WinFormsAsync;

public partial class TimerForm : Form
{
    private SevenSegmentTimer _sevenSegmentTimer;
    private readonly CancellationTokenSource _formCloseCancellation = new();

    public TimerForm()
    {
        InitializeComponent();
        SetupTimerDisplay();
    }

    [MemberNotNull(nameof(_sevenSegmentTimer))]
    private void SetupTimerDisplay()
    {
        _sevenSegmentTimer = new SevenSegmentTimer
        {
            Dock = DockStyle.Fill
        };

        Controls.Add(_sevenSegmentTimer);
    }

    override async protected void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await RunDisplayLoopAsyncV6();
    }

    private async Task RunDisplayLoopAsyncV1()
    {
        // When we update the time, the method will also wait 75 ms asynchronously.
        _sevenSegmentTimer.UpdateDelay = 75;

        while (true)
        {
            // We update and then wait for the delay.
            // In the meantime, the Windows message loop can process other messages,
            // so the app remains responsive.
            await _sevenSegmentTimer.UpdateTimeAndDelayAsync(
                time: TimeOnly.FromDateTime(DateTime.Now));
        }
    }

    private async Task RunDisplayLoopAsyncV2()
    {
        // When we update the time, the method will also wait 75 ms asynchronously.
        _sevenSegmentTimer.UpdateDelay = 75;

        // BOOM!
        await Task.Run(ActualDisplayLoopAsync);

        // Local function, which represents the actual loop.
        async Task ActualDisplayLoopAsync()
        {
            while (true)
            {
                // We update and then wait for the delay.
                // In the meantime, the Windows message loop can process other messages,
                // so the app remains responsive.
                await _sevenSegmentTimer.UpdateTimeAndDelayAsync(
                    time: TimeOnly.FromDateTime(DateTime.Now));
            }
        }
    }

    private async Task RunDisplayLoopAsyncV3()
    {
        // When we update the time, the method will also wait 75 ms asynchronously.
        _sevenSegmentTimer.UpdateDelay = 75;

        // This is a local function now, calling the actual loop on the UI Thread.
        Task InvokeTask() => this.InvokeAsync(ActualDisplayLoopAsync, CancellationToken.None);

        await Task.Run(InvokeTask);

        // This takes now a CancellationToken, not only so we have the right signature for InvokeAsync.
        async ValueTask ActualDisplayLoopAsync(CancellationToken cancellation = default)
        {
            while (true)
            {
                // We update and then wait for the delay.
                // In the meantime, the Windows message loop can process other messages,
                // so the app remains responsive.
                await _sevenSegmentTimer.UpdateTimeAndDelayAsync(
                    time: TimeOnly.FromDateTime(DateTime.Now),
                    cancellation: cancellation);
            }
        }
    }

    private async Task RunDisplayLoopAsyncV4()
    {
        while (true)
        {
            // We also have methods to fade the separators in and out!
            // And note: There is not need to Invoke the methods, because we can safely
            // set the color for a label from any thread.
            await _sevenSegmentTimer.FadeSeparatorsInAsync().ConfigureAwait(false);
            await _sevenSegmentTimer.FadeSeparatorsOutAsync().ConfigureAwait(false);
        }
    }

    // Well, this is not quite it!
    private async Task RunDisplayLoopAsyncV5()
    {
        while (true)
        {
            await FadeInFadeOutAsync().ConfigureAwait(false);
        }

        // Let's group this in one task.
        async Task FadeInFadeOutAsync()
        {
            await _sevenSegmentTimer.FadeSeparatorsInAsync().ConfigureAwait(false);
            await _sevenSegmentTimer.FadeSeparatorsOutAsync().ConfigureAwait(false);
        }

    }

    // But this is.
    // But this is.
    private async Task RunDisplayLoopAsyncV6()
    {
        Task? uiUpdateTask = null;
        Task? separatorFadingTask = null;

        while (true)
        {
            async Task FadeInFadeOutAsync(CancellationToken cancellation)
            {
                await _sevenSegmentTimer.FadeSeparatorsInAsync(cancellation).ConfigureAwait(false);
                await _sevenSegmentTimer.FadeSeparatorsOutAsync(cancellation).ConfigureAwait(false);
            }

            uiUpdateTask ??= _sevenSegmentTimer.UpdateTimeAndDelayAsync(
                time: TimeOnly.FromDateTime(DateTime.Now),
                cancellation: _formCloseCancellation.Token);

            separatorFadingTask ??= FadeInFadeOutAsync(_formCloseCancellation.Token);
            Task completedOrCancelledTask = await Task.WhenAny(separatorFadingTask, uiUpdateTask);

            if (completedOrCancelledTask.IsCanceled)
            {
                break;
            }

            if (completedOrCancelledTask == uiUpdateTask)
            {
                uiUpdateTask = null;
            }
            else
            {
                separatorFadingTask = null;
            }
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        _formCloseCancellation.Cancel();
    }
}
