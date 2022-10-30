using System;
using System.Windows.Forms;
using TileRepeater.Data.ListController;

namespace TileRepeaterDemo
{
    public partial class MainForm : Form
    {
        private string? _pathToPictures;
        private readonly UIController _uiController;

        public MainForm()
        {
            InitializeComponent();
            _uiController = new UIController();
        }

        private void SetPathToImageFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Open Path to Images",
                RootFolder = Environment.SpecialFolder.MyPictures
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
    }
}
