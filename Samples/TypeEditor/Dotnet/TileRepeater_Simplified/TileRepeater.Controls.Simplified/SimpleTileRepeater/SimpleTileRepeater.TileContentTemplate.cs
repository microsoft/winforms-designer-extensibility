using System.ComponentModel;

namespace WinForms.Tiles.Simplified;

public partial class SimpleTileRepeater
{
    [TypeConverter(typeof(TileContentConverter))]
    public class TileContentTemplate
    {
        public TileContentTemplate()
        {
        }

        public TileContentTemplate(Type userControlType)
        {
            if (userControlType is null)
            {
                throw new ArgumentNullException(nameof(userControlType));
            }

            if (!typeof(TileContent).IsAssignableFrom(userControlType))
            {
                throw new ArgumentException(nameof(userControlType));
            }

            TileContentType = userControlType;
        }

        public string? Name
            => TileContentType?.Name;

        public Type? TileContentType { get; set; }

        public override string ToString()
            => TileContentType?.Name ?? "(none)";
    }
}
