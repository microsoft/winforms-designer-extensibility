using System;
using System.Drawing;
using System.Windows.Forms;

namespace SampleRootDesigner
{
    public partial class ShapeRootDesigner
    {
        // RootDesignerView is a simple control that will be displayed 
        // in the designer window.
        private class RootDesignerView : Control
        {
            private ShapeRootDesigner _designer;
            private Cursor _savedCursor;

            protected override Cursor DefaultCursor => base.DefaultCursor;

            public RootDesignerView(ShapeRootDesigner designer)
            {
                _designer = designer;
                BackColor = Color.LightGray;
                Font = new Font(Font.FontFamily.Name, 24.0f);
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);

                _savedCursor = Cursor;
                _designer.VsOutputWindowLogger.WriteLine($"View: MouseEnter");
                object toolboxItem = _designer.ToolboxService.GetSelectedToolboxItem();

                if (toolboxItem is null)
                {
                    toolboxItem = "No toolbox item selected.";
                }

                if (_designer.ToolboxService.SetCursor())
                {
                    Cursor = Cursor.Current;
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                _designer.VsOutputWindowLogger.WriteLine($"View: MouseLeave");
                Cursor = _savedCursor;
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);

                // Draws the name of the component in large letters.
                pe.Graphics.DrawString(_designer.Component.Site.Name, Font, Brushes.Black, ClientRectangle);
            }
        }
    }
}
