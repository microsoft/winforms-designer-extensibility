using System.Drawing;
using System.Windows.Forms;
using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;

namespace RootDesignerDemo.Designer.Server
{
    /// <summary>
    ///  The control designer of the RdControl.
    /// </summary>
    internal partial class RdControlDesigner : ControlDesigner
    {
        /// <summary>
        ///  Attaches the action lists to the control designer.
        /// </summary>
        /// <remarks>
        ///  Note: Action lists for the out-of-process Designer can be implemented exactly as they would be for the in-process
        ///  designer, except: The control designer has to be compiled against the Winforms Designer Extensibility SDK, and ActionList
        ///  related classes must come from the <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
        /// </remarks>
        public override DesignerActionListCollection ActionLists
            => new()
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs paintEventArgs)
        {
            base.OnPaintAdornments(paintEventArgs);

            // If you want to paint custom adorner or other GDI+ based content,
            // use the paintEventArgs' Graphics methods to render it.

            // Drawing the frame around the ClientRectangle with a dotted brush...
            if (!(SelectionService?.GetComponentSelected(Control) ?? false))
            {
                using var pen = new Pen(Control.ForeColor);

                // ...if the control is not currently selected.
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                using var brush = new SolidBrush(Control.ForeColor);

                var clientRect = Control.ClientRectangle;
                clientRect.Inflate(-1, -1);

                paintEventArgs.Graphics.DrawRectangle(pen, clientRect);
            }
        }
    }
}

