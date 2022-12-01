Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

''' <summary>
''' The actual client-side implementation of the CustomTypeEditor, which is called by 
''' Visual Studio's Property Browser.
''' </summary>
Public Class CustomTypeEditor
    Inherits UITypeEditor

    Private _customTypeEditorDialog As CustomTypeEditorDialog

    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

        If provider Is Nothing Then
            Return value
        End If

        Dim editorService = provider.GetRequiredService(Of IWindowsFormsEditorService)()
        Dim designerHost = provider.GetRequiredService(Of IDesignerHost)()

        ' Value now holds the proxy of the CustomPropertyStore object the user wants to edit.
        Dim viewModelClient = CustomTypeEditorVMClient.Create(provider, value)

        _customTypeEditorDialog = If(_customTypeEditorDialog, New CustomTypeEditorDialog(provider, viewModelClient))
        _customTypeEditorDialog.Context = context
        _customTypeEditorDialog.Host = designerHost

        Dim dialogResult = editorService.ShowDialog(_customTypeEditorDialog)

        If dialogResult = System.Windows.Forms.DialogResult.OK Then
            ' By now, the UI of the Editor has asked its (client-side) ViewModel
            ' to run the code which updates the property value. It passes the data to
            ' the server, which in turn updates the server-side ViewModel.
            ' When it's time to return the value from the client-side ViewModel back to the
            ' Property Browser (which has called the TypeEditor in the first place), the client-side
            ' ViewModel accesses its PropertyStore property, which in turn gets the required PropertyStore
            ' proxy object directly from the server-side ViewModel.
            value = viewModelClient.PropertyStore
        End If

        Return value
    End Function

    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle

        Return UITypeEditorEditStyle.Modal
    End Function
End Class
