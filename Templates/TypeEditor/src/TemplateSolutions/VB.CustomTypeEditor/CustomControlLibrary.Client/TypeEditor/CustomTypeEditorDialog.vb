Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports CustomControlLibrary.Protocol.DataTransport

Partial Friend Class CustomTypeEditorDialog
    Inherits Form

    Private _propertyStore As CustomPropertyStoreData

    Public Sub New(ByVal provider As IServiceProvider, ByVal viewModelClient As CustomTypeEditorVMClient)
        InitializeComponent()

        Me.Provider = provider
        Me.ViewModelClient = viewModelClient

        ' Fill the Enum Combobox with the enum values.
        _customEnumValueListBox.Items.AddRange(
            System.Enum.GetValues(GetType(CustomEnumClientVersion)).
                Cast(Of CustomEnumClientVersion)().
                Select(Function(enumValue) enumValue.ToString()).
                ToArray())

        _customEnumValueListBox.SelectedIndex = 0

        ' Fill the Form with the values.
        PropertyStoreData = Me.ViewModelClient.PropertyStoreData
    End Sub

    Public ReadOnly Property Provider() As IServiceProvider
    Public Property ViewModelClient() As CustomTypeEditorVMClient
    Public Property Context() As ITypeDescriptorContext
    Public Property Host() As IDesignerHost

    Public Property PropertyStoreData() As CustomPropertyStoreData
        Get
            Return _propertyStore
        End Get

        Set(ByVal value As CustomPropertyStoreData)
            _requiredIdTextBox.Text = value?.SomeMustHaveId
            _dateCreated.Value = If(value?.DateCreated, DateTime.Now.Date)
            _listOfStringTextBox.Lines = value?.ListOfStrings
            _customEnumValueListBox.SelectedIndex = If(value?.CustomEnumValue, 0)
        End Set
    End Property

    ' Question: "How does this dialog ever get closed?"
    ' In this dialog, the OK button is set as the Form's accept button,
    ' the Cancel button is set as the Form's cancel button.
    ' The OK button's DialogResult is set to OK.
    ' Now, assigning a DialogResult value to a modal Form's DialogResult property
    ' automatically also causes OnValidating to run, and if its CancelEventArgs
    ' are not actually cancelled, the modal Form closes automatically.
    ' There is no need to write any code for that, expect for validating the user input.
    ' So, we neither need to handle the OK click event, nor Cancel click.
    Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)

        If DialogResult = System.Windows.Forms.DialogResult.OK Then
            ViewModelClient.ExecuteOkCommand()
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        e.Cancel = FormValidating()
    End Sub

    Private Function FormValidating() As Boolean
        ' If the user doesn't click OK but cancels then we dont validate but return false.
        ' In this case, the existing content of _propertyStore stays current.
        If DialogResult <> System.Windows.Forms.DialogResult.OK Then
            Return False
        End If

        Dim validationFailed As Boolean = False

        validationFailed = validationFailed Or
            _errorProvider.SetErrorOrNull(
                control:=_requiredIdTextBox,
                errorCondition:=Function() String.IsNullOrWhiteSpace(_requiredIdTextBox.Text),
                errorText:="Please enter some valid ID value (alphanumerical).")

        validationFailed = validationFailed Or
            _errorProvider.SetErrorOrNull(
                control:=_dateCreated,
                errorCondition:=Function() _dateCreated.Value > DateTime.Now,
                errorText:="Date can't be in the future.")

        _propertyStore = If(
            validationFailed,
            Nothing,
            (New CustomPropertyStoreData(
                _requiredIdTextBox.Text,
                _dateCreated.Value,
                _listOfStringTextBox.Lines,
                CByte(Math.Truncate(_customEnumValueListBox.SelectedIndex)))))

        ViewModelClient.PropertyStoreData = _propertyStore

        Return validationFailed
    End Function
End Class
