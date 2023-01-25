using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsCommandBinding.Examples;

/// <summary>
///  Simple implementation of a ViewModel that implements <see cref="INotifyPropertyChanged"/>.
/// </summary>
public class SimpleCommandViewModel : INotifyPropertyChanged
{
    // The event that is fired when a property changes.
    public event PropertyChangedEventHandler? PropertyChanged;

    // Backing field for the properties.
    private bool _sampleCommandAvailability;
    private RelayCommand _sampleCommand;
    private string _sampleCommandResult = "* not invoked yet *";
    private int _invokeCount;

    /// <summary>
    ///  Creates a new instance of the <see cref="SimpleCommandViewModel"/> class.
    /// </summary>
    public SimpleCommandViewModel()
    {
        _sampleCommand = new RelayCommand(ExecuteSampleCommand, CanExecuteSampleCommand);
    }

    /// <summary>
    ///  Controls the command availability and is bound to the CheckBox of the Form.
    /// </summary>
    public bool SampleCommandAvailability
    {
        get => _sampleCommandAvailability;
        
        set
        {
            if (_sampleCommandAvailability == value)
            {
                return;
            }

            _sampleCommandAvailability = value;

            // When this property changes we need to notify the UI that the command availability has changed.
            // The command's availability is reflected through the button's enabled state, which is - 
            // because its command property is bound - automatically updated.
            _sampleCommand.NotifyCanExecuteChanged();

            // Notify the UI that the property has changed.
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///  Command that is bound to the button of the Form.
    ///  When the button is clicked, the command is executed.
    /// </summary>
    public RelayCommand SampleCommand
    {
        get => _sampleCommand;

        set
        {
            if (_sampleCommand == value)
            {
                return;
            }

            _sampleCommand = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///  The result of the command execution, which is bound to the Form's label.
    /// </summary>
    public string SampleCommandResult
    {
        get => _sampleCommandResult;
        
        set
        {
            if (_sampleCommandResult == value)
            {
                return;
            }

            _sampleCommandResult = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///  Method that is executed when the command is invoked.
    /// </summary>
    public void ExecuteSampleCommand()
        => SampleCommandResult = $"Command invoked {_invokeCount++} times.";

    /// <summary>
    ///  Method that determines whether the command can be executed. It reflects the 
    ///  property CommandAvailability, which in turn is bound to the CheckBox of the Form.
    /// </summary>
    public bool CanExecuteSampleCommand()
        => SampleCommandAvailability;

    // Notify the UI that one of the properties has changed.
    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
