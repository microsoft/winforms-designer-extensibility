using TileRepeater.Data.ListController;

namespace TileRepeaterDemo;

public partial class SimplifiedTileRepeaterTestForm : Form
{
    private string? _pathToPictures;
    private readonly UIController _uiController;

    public SimplifiedTileRepeaterTestForm()
    {
        InitializeComponent();
        _uiController = new UIController();
    }

    private void SetPathToImageFilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new()
        {
            Description = "Open Path to Images",
            UseDescriptionForTitle = true
        };

        var dialogResult = folderBrowserDialog.ShowDialog();

        if (dialogResult == DialogResult.OK)
        {
            _pathToPictures = folderBrowserDialog.SelectedPath;
            _imagePathStatusLabel.Text = _pathToPictures;
            _uiController.PictureItems = UIController.GetSimplePictureTemplateItemsFromFolder(_pathToPictures);
            _uiControllerBindingSource.DataSource = _uiController;
        }
    }

    protected override void OnResizeEnd(EventArgs e)
    {
        base.OnResizeEnd(e);
        _simpleTileRepeater.PerformLayout();
    }
}
