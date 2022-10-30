using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class BindableAsyncImageLoaderComponent : Component, IBindableComponent
    {
        public event EventHandler? ImageChanged;
        public event EventHandler? ImageFilenameChanged;

        private BindingContext? _bindingContext;
        private ControlBindingsCollection? _dataBindings;
        public event EventHandler? BindingContextChanged;
        private Image? _image;
        private string? _imageFilename;

        // We're running no more than 2 worker tasks for the image resizing at a time.
        static readonly SemaphoreSlim s_semaphore = new(2);

        public BindableAsyncImageLoaderComponent()
        {
            InitializeComponent();
            Disposed += BindableAsyncImageLoaderComponent_Disposed;
        }

        private void BindableAsyncImageLoaderComponent_Disposed(object? sender, EventArgs e)
            => Image?.Dispose();

        public BindableAsyncImageLoaderComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void UpdateBindings()
        {
            for (int i = 0; i < DataBindings.Count; i++)
            {
                BindingContext.UpdateBinding(BindingContext, DataBindings[i]);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBindingContextChanged(EventArgs e)
        {
            if (_bindingContext is not null)
            {
                UpdateBindings();
            }

            BindingContextChanged?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        [ParenthesizePropertyName(true)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                _dataBindings ??= new ControlBindingsCollection(this);

                return _dataBindings;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingContext BindingContext
        {
            get
            {
                _bindingContext ??= new BindingContext();

                return _bindingContext;
            }
            set
            {
                if (!Equals(_bindingContext, value))
                {
                    _bindingContext = value;
                    OnBindingContextChanged(EventArgs.Empty);
                }
            }
        }

        [Bindable(true), DefaultValue(null)]
        public string? ImageFilename
        {
            get => _imageFilename;

            set
            {
                if (!Equals(_imageFilename, value))
                {
                    _imageFilename = value;
                    OnImageFilenameChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(false)]
        public bool AutoLoad { get; set; }

        protected async virtual void OnImageFilenameChanged(EventArgs e)
        {
            ImageFilenameChanged?.Invoke(this, e);

            if (AutoLoad)
            {
                await LoadImageAsync();
            }
        }

        [Browsable(false)]
        public Image? Image
        {
            get => _image;
            private set
            {
                if (!Equals(_image, value))
                {
                    _image = value;
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        public async virtual Task LoadImageAsync(Size rescaleTo = default)
        {
            if (string.IsNullOrWhiteSpace(_imageFilename))
            {
                if (Image is not null)
                {
                    Image.Dispose();
                    Image = null;
                }

                return;
            }

            try
            {
                Image?.Dispose();
                Image = await LoadImageAsync(_imageFilename!, rescaleTo);

            }
            catch (Exception)
            {
            }
        }

        public virtual void DisposeImage()
        {
            if (Image is not null)
            {
                Image.Dispose();
                Image = null;
            }
        }

        protected virtual void OnImageChanged(EventArgs e)
            => ImageChanged?.Invoke(this, e);

        private static async Task<Image> LoadImageAsync(string fileName, Size rescaleTo = default)
        {
            await s_semaphore.WaitAsync();

            var imageResult = await Task.Run<Image>(() =>
            {
                var image = Image.FromFile(fileName);
                Size rescaleToAligned;

                if (rescaleTo != default)
                {
                    float originalRatio = (float)image.Width / (float)image.Height;
                    float targetRatio = (float)rescaleTo.Width / (float)rescaleTo.Height;

                    // We must do the scaling the other way around, if it is Portrait format.
                    bool flipFlag = originalRatio < 1;

                    if ((originalRatio < targetRatio) ^ flipFlag)
                    {
                        var ratioH = (float)rescaleTo.Height / (float)image.Height;
                        rescaleToAligned = new((int)(image.Width * ratioH), rescaleTo.Height);
                    }
                    else
                    {
                        var ratioW = (float)rescaleTo.Width / (float)image.Width;
                        rescaleToAligned = new(rescaleTo.Width, (int)(image.Height * ratioW));
                    }

                    var imageAligned = new Bitmap(image, rescaleToAligned);
                    image.Dispose();

                    return imageAligned;
                }

                return image;
            });

            s_semaphore.Release();

            return imageResult;
        }
    }
}
