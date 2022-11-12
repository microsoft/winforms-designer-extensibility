using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms.Tiles.Designer.Server
{
    internal partial class TileRepeaterDesigner : ControlDesigner
    {
        private const int DescriptionOffset = 5;

        public override DesignerActionListCollection ActionLists
            => new()
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            string genericAdornmentText =
                  $"{nameof(TileRepeater)}: " +
                  $"{TileRepeaterControl.Name}\n";

            // Let's draw what ever type assignments we have into the control,
            // so the Developer always sees, what Data Template Selection there
            // is at runtime.
            var templatesString = GetAssignmentTypesString();

            pe.Graphics.DrawString(
                genericAdornmentText + templatesString,
                Control.Font,
                new SolidBrush(Control.ForeColor),
                new PointF(DescriptionOffset, DescriptionOffset));

            string GetAssignmentTypesString()
            {
                StringBuilder sBuilder = new();
                sBuilder.AppendLine($"Templates:");
                sBuilder.AppendLine($"------------------------");
                sBuilder.AppendLine($"{nameof(TileRepeater.ItemTemplate)}: {TileRepeaterControl.ItemTemplate}");
                sBuilder.AppendLine($"{nameof(TileRepeater.SeparatorTemplate)}: {TileRepeaterControl.SeparatorTemplate}");

                return sBuilder.ToString();
            }
        }
        private TileRepeater TileRepeaterControl => (TileRepeater)Control;
    }
}
