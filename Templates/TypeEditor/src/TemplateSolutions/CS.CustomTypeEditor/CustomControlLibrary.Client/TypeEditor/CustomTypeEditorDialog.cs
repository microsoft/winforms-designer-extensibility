﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using CustomControlLibrary.Protocol.DataTransport;

namespace CustomControlLibrary.Designer.Client
{
    internal partial class CustomTypeEditorDialog : Form
    {
        CustomPropertyStoreData? _propertyStore;

        public CustomTypeEditorDialog(IServiceProvider provider, CustomTypeEditorVMClient viewModelClient)
        {
            InitializeComponent();

            Provider = provider;
            ViewModelClient = viewModelClient;

            // Fill the Enum Combobox with the enum values.
            _customEnumValueListBox.Items.AddRange(
                Enum.GetValues(typeof(CustomEnumClientVersion))
                .Cast<CustomEnumClientVersion>()
                .Select(enumValue => enumValue.ToString())
                .ToArray());

            _customEnumValueListBox.SelectedIndex = 0;

            // Fill the Form with the values.
            PropertyStoreData = ViewModelClient.PropertyStoreData;
        }

        public IServiceProvider? Provider { get; }
        public CustomTypeEditorVMClient ViewModelClient { get; set; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }

        public CustomPropertyStoreData? PropertyStoreData
        {
            get => _propertyStore;

            set
            {
                _requiredIdTextBox.Text = value?.SomeMustHaveId;
                _dateCreated.Value = value?.DateCreated ?? DateTime.Now.Date;
                _listOfStringTextBox.Lines = value?.ListOfStrings;
                _customEnumValueListBox.SelectedIndex = value?.CustomEnumValue ?? 0;
            }
        }

        // Question: "How does this dialog ever get closed?"
        // In this dialog, the OK button is set as the Form's accept button,
        // the Cancel button is set as the Form's cancel button.
        // The OK button's DialogResult is set to OK.
        // Now, assigning a DialogResult value to a modal Form's DialogResult property
        // automatically also causes OnValidating to run, and if its CancelEventArgs
        // are not actually cancelled, the modal Form closes automatically.
        // There is no need to write any code for that, expect for validating the user input.
        // So, we neither need to handle the OK click event, nor Cancel click.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (DialogResult == DialogResult.OK)
            {
                ViewModelClient.ExecuteOkCommand();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = FormValidating();
        }

        private bool FormValidating()
        {
            // If we're not OK'ing then the validation is always correct.
            // In this case, the existing content of _propertyStore stays current.
            if (DialogResult != DialogResult.OK)
                return false;

            bool validationFailed = false;

            validationFailed |= _errorProvider.SetErrorOrNull(
                control: _requiredIdTextBox,
                errorCondition: () => string.IsNullOrWhiteSpace(_requiredIdTextBox.Text),
                errorText: "Please enter some valid ID value (alphanumerical).");

            validationFailed |= _errorProvider.SetErrorOrNull(
                control: _dateCreated,
                errorCondition: () => _dateCreated.Value > DateTime.Now,
                errorText: "Date can't be in the future.");

            _propertyStore = validationFailed
                ? null
                : (new(
                    _requiredIdTextBox.Text,
                    _dateCreated.Value,
                    _listOfStringTextBox.Lines,
                    (byte)_customEnumValueListBox.SelectedIndex));

            ViewModelClient.PropertyStoreData = _propertyStore;

            return validationFailed;
        }
    }
}
