using System;

namespace TileRepeater.Data.Image;

public struct ImageMetaData
{
    public ImageMetaData(int width, int height, DateTime dateTaken, string filename)
    {
        Width = width;
        Height = height;
        DateTaken = dateTaken;
        Filename = filename;

        ImageOrientation = (width / (float)height) switch
        {
            1 => ImageOrientation.Square,
            < 1 => ImageOrientation.Portrait,
            _ => ImageOrientation.Landscape
        };
    }

    public int Height { get; set; }
    public int Width { get; set; }
    public DateTime DateTaken { get; set; }
    public string Filename { get; set; }
    public ImageOrientation ImageOrientation { get; set; }
}
