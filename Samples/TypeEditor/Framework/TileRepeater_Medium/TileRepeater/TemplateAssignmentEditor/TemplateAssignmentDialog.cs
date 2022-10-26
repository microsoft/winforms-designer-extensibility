using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms.Tiles.Designer
{
    internal partial class TemplateAssignmentDialog : Form
    {
        private bool _suspendListboxUpdates;

        public const string DialogFont = nameof(DialogFont);

        public TemplateAssignmentDialog(IServiceProvider serviceProvider, TemplateAssignmentViewModel viewModel)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            ViewModel = viewModel;

            InitializeComponent();
            
            // Let's go with this as a default:
            _INotifyPropertyChangedFilterCheckBox.Checked = true;

            PopulateContent();

            IUIService uiService = (IUIService) ServiceProvider.GetService(typeof(IUIService));
            Font = (Font)uiService.Styles[DialogFont];
        }

        private void PopulateContent()
        {
            _suspendListboxUpdates = true;

            RepopulateTemplateTypes();

            _tileContentTilesListbox.BeginUpdate();
            _tileContentTilesListbox.Items.AddRange(
                ViewModel!.TileContentTypes
                    .Select((tileTypeItem) => new ListBoxTypeItem(tileTypeItem))
                    .Cast<object>()
                    .ToArray());

            _tileContentTilesListbox.SelectedIndex = -1;
            _tileContentTilesListbox.EndUpdate();

            _suspendListboxUpdates = false;
        }

        private void RepopulateTemplateTypes()
        {
            _templateTypesListBox.BeginUpdate();
            _templateTypesListBox.Items.Clear();

            var templateTypes = ViewModel!.TemplateTypes
                    .Select((templateTypeItem) => new ListBoxTypeItem(templateTypeItem));

            if (_INotifyPropertyChangedFilterCheckBox.Checked)
                templateTypes = templateTypes.Where(
                    item => item.TypeInfo.ImplementsINotifyPropertyChanged);

            _templateTypesListBox.Items.AddRange(
                templateTypes
                .Cast<object>()
                .ToArray());

            _templateTypesListBox.SelectedIndex = -1;
            _templateTypesListBox.EndUpdate();
        }

        // There is no OKButton_Click handler. Don't be confused!
        // This is a modal dialog. Setting the DialogResult closes it.
        // And even that can be automated: By setting the DialogResult value
        // for the respective buttons. We then simply check here,
        // what caused the closing of the Dialog.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (DialogResult == DialogResult.OK)
            {
                ExecuteOkCommand();
            }
        }

        private void TemplateTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendListboxUpdates)
                return;
            else
                UpdateUI();
        }

        private void TileContentTilesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendListboxUpdates)
                return;
            else
                UpdateUI();
        }

        private void ClearSelectionsButton_Click(object sender, EventArgs e)
            => _templateTypesListBox.SelectedIndex = _tileContentTilesListbox.SelectedIndex = -1;

        private void FilterTypesImplementingINotifyPropertyChangedCheckBox_CheckedChanged(object sender, EventArgs e)
            => RepopulateTemplateTypes();

        private void UpdateUI()
        {
            // Get the selected template type.
            TypeInfoData? templateType = _templateTypesListBox.SelectedIndex == -1
                ? null
                : ((ListBoxTypeItem)_templateTypesListBox.SelectedItem)
                    .TypeInfo;
            
            // Get the selected tile content type
            TypeInfoData? tileContentType = _tileContentTilesListbox.SelectedIndex == -1
                ? null
                : ((ListBoxTypeItem)_tileContentTilesListbox.SelectedItem)
                    .TypeInfo;

            // Assign the AssemblyQualifiedName, so we can look up the type server-side for both.
            ViewModel!.TemplateQualifiedTypename = templateType?.AssemblyQualifiedName;
            ViewModel!.TileContentQualifiedTypename = tileContentType?.AssemblyQualifiedName;

            // Controlling the UI...
            if (templateType is null && tileContentType is null)
            {
                // ... Nothing selected, nothing to clear or to OK.
                _clearSelectionsButton.Enabled = false;
                _okButton.Enabled = false;
            }
            else if (templateType is null || tileContentType is null)
            {
                // ... Only one selected, still not enough to OK.
                _okButton.Enabled = false;
            }
            else
            {
                // ... both selected, we can OK and clear.
                _okButton.Enabled = true;
                _clearSelectionsButton.Enabled = true;
            }

            // Update the label in the status strip.
            _resultStatusLabel.Text =
                $"{NullString(templateType?.Name)}/{NullString(tileContentType?.Name)}";

            // Our NullString-Function.
            static string NullString(object? thingToPrint)
                => thingToPrint is null
                    ? "- - -"
                    : thingToPrint.ToString();
        }

        internal void ExecuteOkCommand()
        {
            ViewModel!.OKClick();
        }

        public TemplateAssignment? TemplateAssignment
            => ViewModel!.TemplateAssignment;

        public IServiceProvider ServiceProvider { get; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }
        public TemplateAssignmentViewModel? ViewModel { get; set; }
    }
}
