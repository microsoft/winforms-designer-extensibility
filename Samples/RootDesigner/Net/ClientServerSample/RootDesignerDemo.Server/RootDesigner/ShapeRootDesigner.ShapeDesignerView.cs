using System.ComponentModel.Design;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DotNet.DesignTools.Designers;
using Timer = System.Threading.Timer;
namespace RootDesignerDemo.Designer.Server;

public partial class ShapeRootDesigner
{
    // RootDesignerView is a simple control that will be displayed 
    // in the designer window.
    private class ShapeDesignerView : DesignerScrollableControl
    {
        private Timer? _timer;
        private bool _guard;
        private int _counter = 0;

        public ShapeDesignerView(IRootDesigner rootDesigner) : base(rootDesigner)
        {
            BackColor = Color.LightGray;
            Font = new Font(Font.FontFamily.Name, 24.0f);

            _timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 0, 2000);
        }

        private async void TimerProc(object? state)
        {
            if (_guard)
                return;

            _guard = true;

            await Task.Delay(0);

            Invalidate();

            _counter++;
            _guard = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Draws the name of the component in large letters.
            pe.Graphics.DrawString($"{RootDesigner?.Component?.Site?.Name}: {_counter}", Font, Brushes.Black, ClientRectangle);
        }
    }
}
