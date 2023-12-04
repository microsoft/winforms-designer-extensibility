using System.Drawing;
using System.Windows.Forms;

namespace SampleRootDesigner
{
    public partial class SampleRootDesigner
    {
        // RootDesignerView is a simple control that will be displayed 
        // in the designer window.
        private class RootDesignerView : Control
        {
            private SampleRootDesigner m_designer;

            public RootDesignerView(SampleRootDesigner designer)
            {
                m_designer = designer;
                BackColor = Color.Blue;
                Font = new Font(Font.FontFamily.Name, 24.0f);
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);

                // Draws the name of the component in large letters.
                pe.Graphics.DrawString(m_designer.Component.Site.Name, Font, Brushes.Yellow, ClientRectangle);
            }
        }
    }
}
