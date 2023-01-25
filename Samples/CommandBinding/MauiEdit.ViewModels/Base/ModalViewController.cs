using CommunityToolkit.Mvvm.Input;

namespace MauiEdit.ViewModels;

/// <summary>
///  Base class for ViewModels which are used in modally shown views.
/// </summary>
public abstract partial class ModalViewController : ViewController
{
    public event EventHandler<ModalViewResultEventArgs>? Closed;
    
    public ModalViewController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    ///  Handler for the OK Command. Bind this resulting command to the OK Button of a modal view.
    /// </summary>
    /// <remarks>
    ///  This raises the <see cref="Closed"/> event, which can be consumed by the UI Service,
    ///  which in turn can then pop the view from the view stack of the respected UI. It can then return the control flow
    ///  to the caller of the ShowModal method. The "On" prefix is automatically stripped for the Command name
    ///  generation.
    /// </remarks>
    [RelayCommand()]
    protected virtual void OnOK()
    {
        Closed?.Invoke(this, new ModalViewResultEventArgs("OK"));
    }

    /// <summary>
    ///  Handler for the Cancel command. Bind this resulting command to the Cancel Button of a modal view.
    /// </summary>
    [RelayCommand()]
    protected virtual void OnCancel()
    {
        Closed?.Invoke(this, new ModalViewResultEventArgs("Cancel"));
    }
}
