using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
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
        private BufferedRenderer? _surfaceRenderer;
        private GraphicsPath? _currentSelectionRenderer;

        public ShapeDesignerView(IRootDesigner rootDesigner) : base(rootDesigner)
        {
            BackColor = Color.LightGray;
            ForeColor = Color.Black;

            Font = new Font(Font.FontFamily.Name, 24.0f);

            _timer = new System.Threading.Timer(new TimerCallback(TimerProc), null, 0, 2000);

            // Add a Label and a Button to the Controls Collection:
            Controls.Add(new Label()
            {
                Text = "Hello World",
                Location = new Point(10, 200),
                Size= new Size(200, 50)
            });

            Controls.Add(new Button()
            {
                Text = "Click Me",
                Location = new Point(10, 250),
                Size = new Size(200, 50)
            });
        }

        // We want a transparent overlay window automatically created to draw adorners on.
        // To that end, we return true here. The paint event for that transparent adorner window
        // will then surface in the PostPaint event, passing the Graphics object of the adorner window.
        protected override bool SupportPostPaint => true;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // If we had recreate the handle, we need to re-register the SurfaceRenderer.
            if (_surfaceRenderer is not null)
            {
                _surfaceRenderer.Dispose();
            }

            _surfaceRenderer = new BufferedRenderer(this);
            _surfaceRenderer.Paint += SurfaceRendererPaint;
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (_surfaceRenderer is not null)
            {
                _surfaceRenderer.Paint -= SurfaceRendererPaint;
            }
            base.Dispose(disposing);
        }

        private void TimerProc(object? state)
        {
            // We are requesting an Invalidation of the internal adorner windows, which we inserted in the stack,
            // since this component overwrites SupportPostPaint, and therefore requests a transparent overlay window
            // to be created. Its paint event can then be handled in OnPostPaint.
            if (!this.IsHandleCreated)
            {
                return;
            }

            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    if (_guard)
                        return;

                    _guard = true;
                    _surfaceRenderer?.Invalidate();

                    _counter++;
                    _guard = false;

                }
                catch (Exception)
                {
                }
            }));
        }

        // When SupportPostPaint returns true, we create a transparent overlay, and route the paint event
        // to the Surface Renderer, which is a BufferedRenderer, which will do the adorner painting.
        private void SurfaceRendererPaint(object? sender, PaintEventArgs e)
        {
            // Draws the name of the component in large letters.
            e.Graphics.DrawString($"{RootDesigner?.Component?.Site?.Name}: {_counter}", Font, Brushes.Blue, ClientRectangle);
            e.Graphics.DrawPath(Pens.Blue, CurrentSelectionRenderer);
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
            if (!_drawControlInProgress)
                return;

            CurrentSelectionRenderer.Reset();
            _drawControlInProgress = false;
            _initialPosition = Point.Empty;
            _screenRectangle = Rectangle.Empty;
            _surfaceRenderer?.Invalidate();
        }

        internal GraphicsPath CurrentSelectionRenderer
        {
            get
            {
                if (_currentSelectionRenderer is null)
                {
                    _currentSelectionRenderer = new GraphicsPath();
                }

                return _currentSelectionRenderer;
            }
        }

        // Note: See note above.
        protected override void OnMouseMove(InputDispatchEventArgs e)
        {
            base.OnMouseMove(e);

            if (!_drawControlInProgress)
                return;

            if (_initialPosition.IsEmpty)
            {
                _initialPosition = e.Location;
            }

            Size rectangleSize = new Size(Math.Abs(_initialPosition.X - e.Location.X), Math.Abs(_initialPosition.Y - e.Location.Y));
            Rectangle currentSelectionArea = new(_initialPosition, rectangleSize);

            _screenRectangle = currentSelectionArea;
            CurrentSelectionRenderer.Reset();
            CurrentSelectionRenderer.AddRectangle(_screenRectangle);
            _surfaceRenderer?.Invalidate();
        }
    }
}
