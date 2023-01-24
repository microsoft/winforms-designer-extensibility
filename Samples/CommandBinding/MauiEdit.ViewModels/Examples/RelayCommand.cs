using System.Windows.Input;

namespace WinFormsCommandBinding.Examples;

/// <summary>
///  Implementation example of ICommand - simplified version for the blog post, not taking parameters into account.
/// </summary>
public class RelayCommand : ICommand
{
    // Event which is fired, when the execution context of the command changes.
    public event EventHandler? CanExecuteChanged;

    // Backing field for the Action which is executed when the command is invoked.
    private readonly Action _commandAction;

    // Backing field for the delegate which tests if the command can be executed.
    private readonly Func<bool>? _canExecuteCommandAction;

    /// <summary>
    ///  Creates a new instance of the RelayCommand class.
    /// </summary>
    public RelayCommand(Action commandAction, Func<bool>? canExecuteCommandAction = null)
    {
        ArgumentNullException.ThrowIfNull(commandAction, nameof(commandAction));

        _commandAction = commandAction;
        _canExecuteCommandAction = canExecuteCommandAction;
    }

    // Implicit interface implementations, since there will never be the necessity to call this 
    // method directly. It will always exclusively be called by the bound command control.
    bool ICommand.CanExecute(object? parameter)
        => _canExecuteCommandAction is null || _canExecuteCommandAction.Invoke();

    // Same applies for the Execute method.
    void ICommand.Execute(object? parameter)
        => _commandAction.Invoke();

    /// <summary>
    ///  Triggers sending a notification that the command's execution context has changed.
    /// </summary>
    public void NotifyCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
