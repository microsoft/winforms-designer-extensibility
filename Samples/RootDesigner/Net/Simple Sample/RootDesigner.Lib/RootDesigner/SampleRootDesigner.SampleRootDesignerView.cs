using System.Diagnostics;
using Microsoft.DotNet.DesignTools.AsyncToolbox;
using Microsoft.DotNet.DesignTools.Designers;

namespace RootDesignerDemo;

public partial class ShapeRootDesigner
{
    // RootDesignerView is a simple control that will be displayed 
    // in the designer window.
    private class SampleRootDesignerView : RootDesignerView
    {
        private ShapeRootDesigner _designer;
        private IAsyncToolboxService _asyncToolboxService;
        private System.Threading.Timer _timer;
        private bool _guard;
        private int _counter = 0;

        public SampleRootDesignerView(ShapeRootDesigner designer)
        {
            _designer = designer;
            BackColor = Color.LightGray;
            Font = new Font(Font.FontFamily.Name, 24.0f);

            _asyncToolboxService = designer.GetRequiredService<IAsyncToolboxService>();
            _timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 0, 2000);
        }

        private async void TimerProc(object? state)
        {
            if (_guard)
                return;

            _guard = true;

            if (Debugger.IsAttached)
                Debugger.Break();

            if (_asyncToolboxService != null)
            {
                await _asyncToolboxService.SetCursorAsync();
            }

            Invalidate();

            _counter++;
            _guard = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draws the name of the component in large letters.
            pe.Graphics.DrawString($"{_designer.Component.Site.Name}: {_counter}", Font, Brushes.Black, ClientRectangle);
        }
    }
}
