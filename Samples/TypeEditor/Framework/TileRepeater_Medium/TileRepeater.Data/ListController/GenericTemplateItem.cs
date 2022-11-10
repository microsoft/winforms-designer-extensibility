using CommunityToolkit.Mvvm.ComponentModel;

namespace TileRepeater.Data.ListController
{
    public partial class GenericTemplateItem : ObservableObject
    {
        // This attribute automatically generates the Property in a way ...
        [ObservableProperty]
        private string? _label;

        // ...so it's raising the correct INotifyPropertyChanged. Like this:
        // public string? Label
        // {
        //     get => _label;
        //     set => SetProperty(ref _label, value);
        // }
    }
}
