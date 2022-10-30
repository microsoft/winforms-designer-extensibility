using System.Drawing;
using System.Windows.Forms;
using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class GroupSeperatorContent : TileContent
    {
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

            // Note: Both Pen and Brush get automatically reused.
            e.Graphics.DrawLine(
                new Pen(new SolidBrush(ForeColor), 3),
                new(0, Height / 2),
                new(Width, Height / 2));
        }
    }
}
