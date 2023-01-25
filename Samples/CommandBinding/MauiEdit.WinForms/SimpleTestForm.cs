using WinFormsCommandBinding.Examples;

namespace WinFormsCommandBindingDemo;

public partial class SimpleTestForm : Form
{
    public SimpleTestForm()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        simpleCommandViewModelBindingSource.DataSource = new SimpleCommandViewModel();
    }
}
