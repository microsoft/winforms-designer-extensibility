using WinForms.Tiles.Simplified;

namespace TileRepeaterDemo.SimplifiedTileTemplates;

public partial class ImageContent : TileContent
{
    private TileSize _tileSize = TileSize.Medium;

    public ImageContent()
    {
        InitializeComponent();
        BindingSourceComponent = _genericPictureItemBindingSource;
    }

    public TileSize TileSize
    {
        get => _tileSize;

        set
        {
            if (!Equals(_tileSize, value))
            {
                _tileSize = value;
                OnTileSizeChanged(EventArgs.Empty);
            }
        }
    }

    protected virtual void OnTileSizeChanged(EventArgs e)
    { }

    protected virtual Size BaseDefaultSize => new Size(200, 200);

    public override Size GetPreferredSize(Size proposedSize)

        // For this sample: DPI in DPIAware modes is NOT taken into account!
        => BaseDefaultSize * (int)TileSize + new Size(0, _infoLabel.Height);

    protected async override Task<bool> LoadContentCoreAsync()
    {
        // We ask to load the picture, but rescale it so it comes
        // closest to the PreferredSize of the derivative of this
        // TileContent/ImageContent (it actually gets centered in it).
        await _imageLoaderComponent.LoadImageAsync(PreferredSize);

        if (_imageLoaderComponent.Image is not null)
        {
            _pictureBox.Invalidate();
            return true;
        }

        return false;
    }

    protected override void DisposeContent()
    {
        _imageLoaderComponent.DisposeImage();
    }

    private void PictureBox_Paint(object sender, PaintEventArgs e)
    {
        if (_imageLoaderComponent.Image is { } image)
        {
            var preferredSize = PreferredSize;
            var contentRatio = (float)preferredSize.Width / (float)preferredSize.Height;
            var imageRatio = (float)image.Size.Width / (float)image.Size.Height;

            if (contentRatio < imageRatio)
            {
                e.Graphics.DrawImage(
                    image,
                    x: preferredSize.Width / 2 - image.Size.Width / 2,
                    y: 0);
            }
            else
            {
                e.Graphics.DrawImage(
                    image,
                    x: 0,
                    y: preferredSize.Height / 2 - image.Size.Height / 2);
            }
        }
    }
}
