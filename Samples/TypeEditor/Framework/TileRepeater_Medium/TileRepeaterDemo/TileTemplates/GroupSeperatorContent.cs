using System;
using System.Drawing;
using System.Windows.Forms;
using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class GroupSeperatorContent : TileContent
    {
        private Pen? _foreColorPen;

        public GroupSeperatorContent()
        {
            InitializeComponent();
            BindingSourceComponent = _genericTemplateItemBindingSource;
        }

        public override bool IsSeparator => true;

        public override bool RequestFarSideAnchoring => true;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Note: both Pen and Brush get automatically reused.
            e.Graphics.DrawLine(ForeColorPen,
                new(0, Height / 2),
                new(Width, Height / 2));
        }

        protected override void OnForeColorChanged(EventArgs e)
            => _foreColorPen = null;

        private Pen ForeColorPen
            => _foreColorPen ?? new Pen(new SolidBrush(ForeColor), width: 3);
    }
}
