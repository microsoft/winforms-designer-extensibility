using MauiEdit.ViewModels;

using static WinFormsCommandBindingDemo.Program;

namespace WinFormsCommandBindingDemo;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        DataContext = new MainFormController(SimpleServiceProvider.GetInstance());
    }

    private void MainForm_DataContextChanged(object sender, EventArgs e)
        => _mainFormControllerBindingSource.DataSource = DataContext;
}
