using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsCommandBinding.Examples;

/// <summary>
///  Simple implementation example of <see cref="INotifyPropertyChanged"/>.
/// </summary>
public class SimpleNotifyChangedImplementation : INotifyPropertyChanged
{
    // The event that fires when we want listening instances that one of our properties has changed.
    public event PropertyChangedEventHandler? PropertyChanged;

    // Backing fields for some example properties.
    private string? _lastName;
    private string? _firstName;

    // A property that is being monitored.
    public string? LastName
    {
        get => _lastName;
        
        set
        {
            // Nothing really changed, so we can skip the update.
            if (_lastName == value)
            {
                return;
            }
            
            _lastName = value;

            // Notify listening Views that this property has changed.
            // Using CallerMemberName at the call site will automatically fill in
            // the name of the property that changed.
            OnPropertyChanged();
        }
    }

    public string? FirstName
    {
        get => _firstName;

        set
        {
            if (_firstName == value)
            {
                return;
            }

            _firstName = value;
            OnPropertyChanged();
        }
    }

    // Properties should call this method to notify listening instances that the value has changed.
    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
