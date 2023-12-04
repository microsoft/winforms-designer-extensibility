using System.Windows.Forms.Design;

namespace IToolboxServiceExample
{
    // This designer passes window messages to the controls at design time.    
    public class WindowMessageDesigner : ControlDesigner
    {
        public WindowMessageDesigner()
        {
        }

        // Window procedure override passes events to control.
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.HWnd == this.Control.Handle)
                base.WndProc(ref m);
            else
                this.DefWndProc(ref m);
        }
    }
}
