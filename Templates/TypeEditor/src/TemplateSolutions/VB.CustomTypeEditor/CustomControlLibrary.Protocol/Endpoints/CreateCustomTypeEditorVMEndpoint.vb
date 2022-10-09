Imports System.Composition
Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Endpoint for the method to create the <c>CustomTypeEditor's</c> ViewModel.
    ''' </summary>
    ''' <remarks>
    '''  'ViewModel' in this context is a class which holds the logic/properties to control the UI. There is a 
    '''  server-side and a client-side part of that view model. The server-side provides the logic based on the actual
    '''  types of CustomTypeEditor, running in the context of the custom control's TFM. It communicates to the 
    '''  client-side view model, which then controls the client-side hosted UI, running in the context of 
    '''  Visual Studio.
    '''  For every endpoint there is a request class and a response class for transporting the necessary data
    '''  to the respective context. There is also an additional endpoint handler, which holds the code that executes the actual
    '''  functionality of that endpoint. Request and response are located in the communications assembly; the actual handler is 
    '''  part of the server-side implementation of the CustomControl, along with the actual control designer and the 
    '''  server-side view model.
    ''' </remarks>
    <[Shared]>
    <ExportEndpoint>
    Public Class CreateCustomTypeEditorVMEndpoint
        Inherits Endpoint(Of CreateCustomTypeEditorVMRequest, CreateCustomTypeEditorVMResponse)

        Public Overrides ReadOnly Property Name() As String
            Get
                Return EndpointNames.CreateCustomTypeEditorVM
            End Get
        End Property

        Protected Overrides Function CreateRequest(ByVal reader As IDataPipeReader) As CreateCustomTypeEditorVMRequest
            Return New CreateCustomTypeEditorVMRequest(reader)
        End Function

        Protected Overrides Function CreateResponse(ByVal reader As IDataPipeReader) As CreateCustomTypeEditorVMResponse
            Return New CreateCustomTypeEditorVMResponse(reader)
        End Function
    End Class
End Namespace
