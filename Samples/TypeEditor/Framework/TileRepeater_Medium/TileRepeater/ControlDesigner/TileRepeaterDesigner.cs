using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms.Tiles.Designer
{
    internal partial class TileRepeaterDesigner : ControlDesigner
    {
        private readonly string NotDefinedText =
            $"No assignments.\n" +
            $"Please set the {nameof(TileRepeater.ItemTemplate)} property\n" +
            $"for Data Template selection assignments.";

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
