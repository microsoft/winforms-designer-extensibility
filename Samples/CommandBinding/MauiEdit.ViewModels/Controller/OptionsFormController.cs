using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiEdit.ViewModels;

/// <summary>
///  Provides the UI Controller (ViewModel) for the modally shown Options page.
/// </summary>
public partial class OptionsFormController : ModalViewController
{
    [ObservableProperty]
    private bool _boolOption;

    [ObservableProperty]
    private string? _textOption;

    [ObservableProperty]
    private float? _numericOption;

    [ObservableProperty]
    private DateTime _dateOption;

    public OptionsFormController(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }

    public override string ToString()
        => $"BoolOption: {BoolOption}, TextOption: {TextOption}, NumericOption: {NumericOption}, DateOption: {DateOption}";
}
