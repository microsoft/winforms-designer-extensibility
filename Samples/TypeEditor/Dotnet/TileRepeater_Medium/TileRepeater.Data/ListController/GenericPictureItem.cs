using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TileRepeater.Data.Image;

namespace TileRepeater.Data.ListController
{
    public partial class GenericPictureItem : GenericTemplateItem
    {
        // This attribute automatically generates the Property in a way so it's raising the correct INotifyPropertyChanged.
        [ObservableProperty]
        private string? _filename;

        [ObservableProperty]
        private int _width;

        [ObservableProperty]
        private int _height;

        [ObservableProperty]
        private DateTime? _dateTaken;

        public GenericPictureItem(ImageMetaData imageMetaData)
        {
            Width = imageMetaData.Width;
            Height = imageMetaData.Height;
            DateTaken = imageMetaData.DateTaken;
            Filename = imageMetaData.Filename;
        }
    }
}
