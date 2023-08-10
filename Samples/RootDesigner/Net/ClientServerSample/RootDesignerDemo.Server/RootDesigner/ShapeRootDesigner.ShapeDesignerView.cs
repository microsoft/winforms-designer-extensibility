using System;
using System.ComponentModel.Design;
using System.Diagnostics;
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
        private Rectangle _currentSelectionArea;
        private Point _initialPosition;
        private int _debugCount;

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

            Invalidate();

            _counter++;
            _guard = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Draws the name of the component in large letters.
            pe.Graphics.DrawString($"{RootDesigner?.Component?.Site?.Name}: {_counter}", Font, Brushes.Black, ClientRectangle);
        }

        protected override void OnPostPaint(PaintEventArgs e)
        {
            base.OnPostPaint(e);
        }

        protected override void OnMouseDown(MouseButtonDispatchEventArgs e)
        {
            base.OnMouseDown(e);
            _drawControlInProgress= true;
        }

        protected override void OnMouseUp(MouseButtonDispatchEventArgs e)
        {
            _drawControlInProgress = false;
            // TODO: OnDrawSelectionFinished.
            _initialPosition = Point.Empty;
            _currentSelectionArea = Rectangle.Empty;
            _debugCount = 0;
        }

        protected override void OnMouseMove(InputDispatchEventArgs e)
        {
            base.OnMouseMove(e);

            if (!_drawControlInProgress)
                return;

            _debugCount++;
            if (_debugCount>50)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();

                _debugCount = 0;
            }

            if (!_initialPosition.IsEmpty)
            {
                ControlPaint.DrawReversibleFrame(_currentSelectionArea, Color.Black, FrameStyle.Thick);
            }
            else
            {
                _initialPosition = e.Location;
            }

            Size rectangleSize = new Size(Math.Abs(_initialPosition.X - _initialPosition.X), Math.Abs(e.Location.Y - e.Location.Y));
            _currentSelectionArea = new(_initialPosition, rectangleSize);

            ControlPaint.DrawReversibleFrame(_currentSelectionArea, Color.Black, FrameStyle.Thick);
        }
    }
}
