namespace WinFormsCommandBindingDemo;

/// <summary>
///  Demo Form, showing how to use modal dialogs from a UI-Controller/ViewModel.
/// </summary>
/// <remarks>
///  Please note:
///  1. Set the <see cref="DialogResult"/> property of the Form's OK button to <see cref="DialogResult.OK"/>.
///  2. Set the <see cref="DialogResult"/> property of the Form's Cancel button to <see cref="DialogResult.Cancel"/>.
///  3. Bind the Form to the UI-Controller/ViewModel which needs to be based on the <see cref="ModalViewController"/> class.
///  4. Make sure, that you handle the <see cref="Control.DataContextChanged"/> event of the Form and assign
///     DataContext to the <see cref="BindingSource"/> component, which actually handles the binding.
///  5. Call the <see cref="ModalViewController.ShowDialog"/> method from the ViewModel to show the Form modally.
/// </remarks>
public partial class OptionsForm : Form
{
    public OptionsForm()
    {
        InitializeComponent();
    }

    private void OptionsForm_AssignDataContext(object sender, EventArgs e)
        => _optionsFormControllerBindingSource.DataSource = DataContext;
}
