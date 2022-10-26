using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.Tiles
{
    public partial class Tile : UserControl
    {
        private const int SelectionFramePadding = 20;
        private bool _isInParentClientArea;

        public Tile()
        {
            InitializeComponent();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size=TileContent.GetPreferredSize(proposedSize);
            size += new Size(Padding.Left, Padding.Top) + 
                new Size(Padding.Right, Padding.Bottom);

            return size;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (Parent is not null)
            {
                IsInParentClientArea =
                    !(Bottom < 0 ||
                    Top > Parent.ClientSize.Height ||
                    Right < 0 ||
                    Left > Parent.ClientSize.Width);
            }
        }

        public virtual bool IsInParentClientArea
        {
            get => _isInParentClientArea;
            set
            {
                if (_isInParentClientArea!=value)
                {
                    _isInParentClientArea = value;
                    OnIsInParentClientAreaChanged();
                }
            }
        }

        protected virtual async void OnIsInParentClientAreaChanged()
        {
            if (TileContent is not null && IsInParentClientArea && !TileContent.IsContentLoaded)
            {
                try
                {
                    // This is a fire-and-forget,
                    // so we need to catch a potential
                    // exception of the async content load
                    // and just swallow it.
                    await TileContent.LoadContentAsync();
                }
                catch (Exception)
                {
                }
            }
        }

        public TileContent TileContent
        {
            get
            {
                if (_contentPanel.Controls.Count == 0)
                {
                    _contentPanel.Controls.Add(new TileContent()
                    {
                        Dock = DockStyle.Fill,
                    });
                }

                return (_contentPanel.Controls[0] as TileContent)!;
            }
            set
            {
                if (_contentPanel.Controls.Count > 0)
                {
                    _contentPanel.Controls.Clear();
                }

                var tileContent = value;
                tileContent.Dock = DockStyle.Fill;
                tileContent.Enabled = true;

                _contentPanel.Controls.Add(tileContent);
            }
        }
    }
}
