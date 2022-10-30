using MetadataExtractor;
using System;
using TileRepeater.Data.Image;

namespace TileRepeater.Data.ListController
{
    public class GenericPictureItem : GenericTemplateItem
    {
        private Tag? _metaDataTag;
        private string? _filename;
        private int _width;
        private int _height;
        private DateTime? _dateTaken;

        public GenericPictureItem(ImageMetaData imageMetaData)
        {
            Width = imageMetaData.Width;
            Height = imageMetaData.Height;
            DateTaken = imageMetaData.DateTaken;
            Filename = imageMetaData.Filename;
        }

        public string? Filename
        {
            get => _filename;
            set => SetProperty(ref _filename, value);
        }

        public Tag? MetadataTag
        {
            get => _metaDataTag;
            set => SetProperty(ref _metaDataTag, value);
        }

        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public DateTime? DateTaken
        {
            get => _dateTaken;
            set => SetProperty(ref _dateTaken, value);
        }
    }
}
