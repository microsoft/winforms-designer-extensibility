using TileRepeater.Data.ListController;

namespace TileRepeaterDemo
{
    public partial class TileRepeaterTestForm : Form
    {
        private string? _pathToPictures;
        private readonly UIController _uiController;

        public TileRepeaterTestForm()
        {
            InitializeComponent();
            _uiController = new UIController();
        }

        private void SetPathToImageFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Open Path to Images",
                UseDescriptionForTitle = true
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
