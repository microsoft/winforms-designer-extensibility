using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using TileRepeater.Data.Image;

namespace TileRepeater.Data.ListController
{
    public class UIController : ObservableObject
    {
        // We limit the scenario to jpegs for now.
        //private const string DefaultFileSearchPattern = "*.bmp|*.png|*.jpg|*.jpeg|*.gif|*.ico|*.tif|*.tiff|*.raw|*.arw|*.heic|*.nef|*.cr2";
        private const string DefaultFileSearchPattern = "*.jpg|*.jpeg";

        private static readonly string[] s_defaultFileSearchPattern;

        static UIController()
        {
            s_defaultFileSearchPattern = DefaultFileSearchPattern.Replace("*", "").Split('|');
        }

        private BindingList<GenericTemplateItem>? _templateItems;
        private BindingList<GenericPictureItem>? _pictureItems;

        public BindingList<GenericTemplateItem>? TemplateItems
        {
            get => _templateItems;
            set => SetProperty(ref _templateItems, value);
        }

        public BindingList<GenericPictureItem>? PictureItems
        {
            get => _pictureItems;
            set => SetProperty(ref _pictureItems, value);
        }

        public static BindingList<GenericPictureItem>? GetSimplePictureTemplateItemsFromFolder(
            string filePath,
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            DirectoryInfo directoryInfo = new(filePath);
            BindingList<GenericPictureItem>? pictureItems = new();

            var filesInPath = directoryInfo.GetFiles("*.*", searchOption)
                .Where(file => s_defaultFileSearchPattern.Any(extension => extension == file.Extension))
                .OrderByDescending(file => file.LastWriteTime)
                .ToList();

            if (filesInPath.Count == 0)
            {
                return pictureItems;
            }

            foreach (var file in filesInPath)
            {
                var imageMetaData = file.GetImageMetaData();
                if (imageMetaData is not null)
                {
                    pictureItems.Add(new GenericPictureItem(imageMetaData.Value));
                }
            }

            return pictureItems;
        }

        public static BindingList<GenericTemplateItem>? GetPictureTemplateItemsFromFolder(
        string filePath,
        SearchOption searchOption = SearchOption.AllDirectories)
        {
            DirectoryInfo directoryInfo = new(filePath);
            BindingList<GenericTemplateItem>? pictureItems = new();

            var filesInPath = directoryInfo.GetFiles("*.*", searchOption)
                .Where(file => s_defaultFileSearchPattern.Any(extension => extension == file.Extension))
                .OrderByDescending(file => file.LastWriteTime)
                .ToList();

            if (filesInPath.Count == 0)
            {
                return pictureItems;
            }

            // We set DateTime MinValue, so we start with the group separator unconditionally.
            DateTime currentDate = DateTime.MinValue;

            foreach (var file in filesInPath)
            {
                var fileDate = file.LastWriteTime;

                // Grouping by months is hardwired. Should be suffice for demo purposes.
                if ($"{currentDate.Year}{currentDate.Month}" != $"{fileDate.Year}{fileDate.Month}")
                {
                    currentDate = fileDate;
                    pictureItems.Add(new GenericTemplateItem()
                    {
                        Label = $"Pictures of {currentDate:MMMM}, {currentDate:yyyy}"
                    });
                }

                GenericTemplateItem itemToAdd;
                var imageMetaData = file.GetImageMetaData();

                if (imageMetaData is null)
                    continue;

                itemToAdd = new GenericPictureItem(imageMetaData.Value)
                {
                    Label = file.Name
                };

                pictureItems.Add(itemToAdd);
            }

            return pictureItems;
        }
    }
}
