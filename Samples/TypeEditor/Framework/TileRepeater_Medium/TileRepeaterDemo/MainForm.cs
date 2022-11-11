using System;
using System.Windows.Forms;
using TileRepeater.Data.ListController;

namespace TileRepeaterDemo
{
    public partial class MainForm : Form
    {
        private string? _pathToPictures;
        private readonly UIController _uiController;

        private DarkProfessionalColorTable _darkColorTable = new();
        private ToolStripProfessionalRenderer _darkRenderer;

        public MainForm()
        {
            InitializeComponent();

            _darkRenderer = new ToolStripProfessionalRenderer(_darkColorTable);
            MainMenuStrip.Renderer = _darkRenderer;
            _statusStrip.Renderer = _darkRenderer;
            ApplyDarkSystemColors(MainMenuStrip.Items);
            ApplyDarkSystemColors(_statusStrip.Items);

            _uiController = new UIController();
        }

        private void SetPathToImageFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Open Path to Images",
                RootFolder = Environment.SpecialFolder.Desktop
            };

            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _pathToPictures = folderBrowserDialog.SelectedPath;
                _imagePathStatusLabel.Text = _pathToPictures;
                _uiController.TemplateItems = UIController.GetPictureTemplateItemsFromFolder(_pathToPictures);
                _uiControllerBindingSource.DataSource = _uiController;
            }
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            _pictureTileRepeater.PerformLayout();
        }

        private void ApplyDarkSystemColors(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripItem item in toolStripItems)
            {
                item.BackColor = _darkColorTable.Control;
                item.ForeColor = _darkColorTable.MenuText;

                if (item is ToolStripDropDownItem dropDownItem)
                {
                    if (dropDownItem.HasDropDownItems)
                    {
                        ApplyDarkSystemColors(dropDownItem.DropDownItems);
                    }
                }
            }
        }
    }
}
