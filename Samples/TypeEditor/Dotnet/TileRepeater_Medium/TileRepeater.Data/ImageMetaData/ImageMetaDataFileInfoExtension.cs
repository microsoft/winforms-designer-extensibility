using MetadataExtractor;
using MetadataExtractor.Formats.Jpeg;
using System.IO;
using System.Linq;

namespace TileRepeater.Data.Image
{
    public static class ImageMetaDataFileInfoExtension
    {
        public static ImageMetaData? GetImageMetaData(this FileInfo fileInfo)
        {
            var directories = ImageMetadataReader.ReadMetadata(fileInfo.FullName);
            var jpegDir = directories.OfType<JpegDirectory>().FirstOrDefault();

            // For simplicity, we concentrate of JPEGs for this sample app.
            if (jpegDir is null)
                return null;

            return new ImageMetaData(
                jpegDir.GetImageWidth(),
                jpegDir.GetImageHeight(),
                fileInfo.LastWriteTime,
                fileInfo.FullName);
        }
    }
}
