using CommunityToolkit.Mvvm.ComponentModel;

namespace TileRepeater.Data.ListController
{
    public class GenericTemplateItem : ObservableObject
    {
        private string? _label;

        public string? Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }
    }
}
