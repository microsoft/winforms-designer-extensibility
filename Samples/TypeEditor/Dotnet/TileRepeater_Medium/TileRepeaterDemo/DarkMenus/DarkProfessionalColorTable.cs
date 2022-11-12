using System.Drawing;
using System.Windows.Forms;

namespace TileRepeaterDemo
{
    internal class DarkProfessionalColorTable : ProfessionalColorTable
    {
        DarkThemedSystemColors _systemColors = new();

        public override Color MenuItemPressedGradientBegin
            => Color.FromArgb(0xFF, 0x60, 0x60, 0x60);

        public override Color MenuItemPressedGradientMiddle
            => Color.FromArgb(0xFF, 0x60, 0x60, 0x60);

        public override Color MenuItemPressedGradientEnd
            => Color.FromArgb(0xFF, 0x60, 0x60, 0x60);

        public override Color MenuItemSelectedGradientBegin
            => Color.FromArgb(0xFF, 0x40, 0x40, 0x40);

        public override Color MenuItemSelectedGradientEnd
            => Color.FromArgb(0xFF, 0x40, 0x40, 0x40);

        public override Color MenuItemSelected
            => _systemColors.ControlDark;

        public override Color MenuStripGradientBegin
            => _systemColors.Control;

        public override Color MenuStripGradientEnd
            => _systemColors.Control;

        public override Color StatusStripGradientBegin
            => _systemColors.Control;

        public override Color StatusStripGradientEnd
            => _systemColors.Control;

        public override Color ToolStripDropDownBackground
            => _systemColors.Control;

        public override Color ImageMarginGradientBegin
            => _systemColors.Control;

        public override Color ImageMarginGradientMiddle
            => _systemColors.Control;

        public override Color ImageMarginGradientEnd
            => _systemColors.Control;

        public Color MenuText => _systemColors.MenuText;
        public Color Control => _systemColors.Control;

        internal class DarkThemedSystemColors : ThemedSystemColors
        {
            public override Color Control => Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            public override Color ControlText => Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0);
            public override Color ControlDark => Color.FromArgb(0xFF, 0x40, 0x40, 0x40);
            public override Color HighlightText => Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            public override Color MenuText => Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0);
            public override Color ButtonFace => Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0);
            public override Color ButtonShadow => Color.FromArgb(0xFF, 0x30, 0x30, 0x30);
        }
    }
}
