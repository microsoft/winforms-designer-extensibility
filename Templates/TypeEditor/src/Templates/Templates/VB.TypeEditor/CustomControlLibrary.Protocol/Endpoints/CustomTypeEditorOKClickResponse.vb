Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Response class for this endpoint. This is not returning any relevant data, but this class is still needed
    '''  to meet the infrastructure conventions.
    ''' </summary>
    Public Class CustomTypeEditorOKClickResponse
        Inherits Response.Empty

        Public Shared Shadows ReadOnly Property Empty() As New CustomTypeEditorOKClickResponse()

        Private Sub New()
        End Sub

        Public Sub New(ByVal reader As IDataPipeReader)
            MyBase.New(reader)
        End Sub
    End Class
End Namespace
