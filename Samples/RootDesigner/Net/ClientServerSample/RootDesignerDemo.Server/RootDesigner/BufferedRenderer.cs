using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.DotNet.DesignTools.Designers;

namespace RootDesignerDemo.Designer.Server;

public class BufferedRenderer : IDisposable
{
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromDC(IntPtr hdc);

    public event PaintEventHandler? Paint;

    private Bitmap? _activeBitmap;
    private Bitmap? _upcomingBitmap;
    private DesignerScrollableControl _parentControl;
    private bool _disposedValue;
    private Control? _adornerOverlay;

    public BufferedRenderer(DesignerScrollableControl parentControl)
    {
        _parentControl = parentControl ?? throw new ArgumentNullException(nameof(parentControl));
        _parentControl.Resize += OnParentControlResize;
        _parentControl.PostPaint += OnParentPostPaint;
    }

    private void InitializeBitmaps()
    {
        if (_disposedValue)
        {
            throw new ObjectDisposedException(nameof(BufferedRenderer));
        }

        _activeBitmap?.Dispose();
        _upcomingBitmap?.Dispose();

        if (_parentControl.ClientSize.Width == 0 || _parentControl.ClientSize.Height == 0)
        {
            return;
        }

        _activeBitmap = new Bitmap(_parentControl.ClientSize.Width, _parentControl.ClientSize.Height, PixelFormat.Format32bppArgb);
        _upcomingBitmap = new Bitmap(_parentControl.ClientSize.Width, _parentControl.ClientSize.Height, PixelFormat.Format32bppArgb);

        _activeBitmap.MakeTransparent();
        _upcomingBitmap.MakeTransparent();

        _activeBitmap.Tag = "activeBitmap";
        _upcomingBitmap.Tag = "upcomingBitmap";
    }

    private void OnParentControlResize(object? sender, EventArgs e)
    {
        InitializeBitmaps();
        Invalidate();
        _adornerOverlay?.Invalidate();
    }

    private void OnParentPostPaint(object? sender, PaintEventArgs e)
    {
        if (_adornerOverlay is null)
        {
            IntPtr hwnd = WindowFromDC(e.Graphics.GetHdc());
            _adornerOverlay = Control.FromHandle(hwnd);
        }

        if (_activeBitmap is null)
        {
            return;
        }

        OnPaintInternal();
    }

    protected virtual void OnPaint(PaintEventArgs e)
        => Paint?.Invoke(this, e);

    public void Invalidate()
    {
        OnPaintInternal();
    }

    private void OnPaintInternal()
    {
        if (_upcomingBitmap is null
            || _activeBitmap is null
            || _adornerOverlay is null)
        {
            return;
        }

        using (Graphics g = Graphics.FromImage(_activeBitmap))
        {
            g.Clear(Color.Transparent);
            OnPaint(new PaintEventArgs(g, _adornerOverlay.ClientRectangle));
            //SwapBitmaps();
        }

        using (Graphics parentGraphics = _adornerOverlay.CreateGraphics())
        {
            var bitmapRectangle = new Rectangle(0, 0, _activeBitmap.Width, _activeBitmap.Height);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorKey(Color.Transparent, Color.Transparent);

            parentGraphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            try
            {
                parentGraphics.DrawImage(
                    image: _activeBitmap!,
                    destRect: bitmapRectangle,
                    srcX: 0,
                    srcY: 0,
                    srcWidth: bitmapRectangle.Width,
                    srcHeight: bitmapRectangle.Height,
                    srcUnit: GraphicsUnit.Pixel,
                    imageAttributes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    private void SwapBitmaps()
    {
        var temp = _activeBitmap;
        _activeBitmap = _upcomingBitmap;
        _upcomingBitmap = temp;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _parentControl.Resize -= OnParentControlResize;
                _parentControl.PostPaint -= OnParentPostPaint;
                _activeBitmap?.Dispose();
                _upcomingBitmap?.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
