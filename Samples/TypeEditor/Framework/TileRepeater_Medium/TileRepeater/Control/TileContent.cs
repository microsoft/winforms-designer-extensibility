using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Tiles
{
    public partial class TileContent : UserControl
    {
        protected const int DefaultSelectionFramePadding = 20;

        public TileContent()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Controls, if the tile should unconditionally start in a new row, and also
        ///  that the next row starts in the left column.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsSeparator => false;

        /// <summary>
        ///  Requests the far side of this control to be anchored on the right side of its parent.
        /// </summary>
        [Browsable(false)]
        public virtual bool RequestFarSideAnchoring => false;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsContentLoaded { get; private set; }

        [Browsable(false)]
        public virtual Padding SelectionFramePadding
            => new(DefaultSelectionFramePadding);

        [Browsable(false)]
        public BindingSource? BindingSourceComponent { get; set; }

        public async Task LoadContentAsync() 
            => IsContentLoaded = await LoadContentCoreAsync();

        protected virtual async Task<bool> LoadContentCoreAsync() 
            => await Task.FromResult(false);

        public virtual void DisposeContent()
        { }
    }
}
