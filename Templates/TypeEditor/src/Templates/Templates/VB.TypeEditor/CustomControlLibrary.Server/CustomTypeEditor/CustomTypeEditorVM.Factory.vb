Imports CustomControlLibrary.Protocol
Imports Microsoft.DotNet.DesignTools.ViewModels

Partial Friend Class CustomTypeEditorVM
    ''' <summary>
    ''' Factory class which generates the CustomTypeEditorViewModel.
    ''' </summary>
    <ExportViewModelFactory(ViewModelNames.CustomTypeEditorVM)>
    Private Class Factory
        Inherits ViewModelFactory(Of CustomTypeEditorVM)

        Protected Overrides Function CreateViewModel(ByVal provider As IServiceProvider) As CustomTypeEditorVM
            Return New CustomTypeEditorVM(provider)
        End Function
    End Class
End Class
