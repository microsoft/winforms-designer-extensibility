Imports System.Composition
Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Endpoint to handle the event when the user clicks the OK button of the custom type editor.
    ''' </summary>
    <[Shared]>
    <ExportEndpoint>
    Public Class CustomTypeEditorOKClickEndpoint
        Inherits Endpoint(Of CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse)

        Public Overrides ReadOnly Property Name() As String
            Get
                Return EndpointNames.CustomTypeEditorEditorOKClick
            End Get
        End Property

        Protected Overrides Function CreateRequest(ByVal reader As IDataPipeReader) As CustomTypeEditorOKClickRequest
            Return New CustomTypeEditorOKClickRequest(reader)
        End Function

        Protected Overrides Function CreateResponse(ByVal reader As IDataPipeReader) As CustomTypeEditorOKClickResponse
            Return New CustomTypeEditorOKClickResponse(reader)
        End Function
    End Class
End Namespace
