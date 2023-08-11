using System;
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
        private bool _drawControlInProgress;
        private Point _initialPosition;
        private Rectangle _screenRectangle;

        public ShapeDesignerView(IRootDesigner rootDesigner) : base(rootDesigner)
        {
            BackColor = Color.LightGray;
            Font = new Font(Font.FontFamily.Name, 24.0f);

            _timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 0, 2000);
        }

        // We want a transparent overlay window automatically created to draw adorners on.
        // To that end, we return true here. The paint event for that transparent adorner window
        // will then surface in the PostPaint event, passing the Graphics object of the adorner window.
        protected override bool SupportPostPaint => true;

        private async void TimerProc(object? state)
        {
            if (_guard)
                return;

            _guard = true;

            await Task.Delay(0);

            // We are requesting an Invalidation of the internal adorner windows, which we inserted in the stack,
            // since this component overwrites SupportPostPaint, and therefore requests a transparent overlay window
            // to be created. Its paint event can then be handled in OnPostPaint.
            RequestPostPaint();

            _counter++;
            _guard = false;
        }

        // When SupportPostPaint returns true, we create a transparent overlay, and its OnPaint is handled here.
        protected override void OnPostPaint(PaintEventArgs e)
        {
            // Draws the name of the component in large letters.
            e.Graphics.DrawString($"{RootDesigner?.Component?.Site?.Name}: {_counter}", Font, Brushes.Black, ClientRectangle);
        }

        // Note: This is NOT the original mouse down, but rather the mouse down, which is
        // triggered by the input dispatcher (and originates from the input shield in the client).
        protected override void OnMouseDown(MouseButtonDispatchEventArgs e)
        {
            base.OnMouseDown(e);
            _drawControlInProgress= true;
        }

        // Note: See note above.
        protected override void OnMouseUp(MouseButtonDispatchEventArgs e)
        {
            _drawControlInProgress = false;
            // TODO: OnDrawSelectionFinished.
            _initialPosition = Point.Empty;
            _screenRectangle = Rectangle.Empty;
        }

        // Note: See note above.
        protected override void OnMouseMove(InputDispatchEventArgs e)
        {
            base.OnMouseMove(e);

            if (!_drawControlInProgress)
                return;

            if (!_initialPosition.IsEmpty)
            {
                ControlPaint.DrawReversibleFrame(_screenRectangle, Color.Black, FrameStyle.Thick);
            }
            else
            {
                _initialPosition = e.Location;
            }

            Size rectangleSize = new Size(Math.Abs(_initialPosition.X - e.Location.X), Math.Abs(_initialPosition.Y - e.Location.Y));
            Rectangle currentSelectionArea = new(_initialPosition, rectangleSize);

            Point topLeft = PointToScreen(new Point(currentSelectionArea.Left, currentSelectionArea.Top));
            Point bottomRight = PointToScreen(new Point(currentSelectionArea.Right, currentSelectionArea.Bottom));
            _screenRectangle = new Rectangle(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

            ControlPaint.DrawReversibleFrame(_screenRectangle, Color.Black, FrameStyle.Thick);
        }
    }
}
