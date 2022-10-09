Imports CustomControlLibrary.Protocol
Imports CustomControlLibrary.Protocol.Endpoints
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Handlers
    ''' <summary>
    ''' The handler for <see cref="CreateCustomTypeEditorVMEndpoint"/>. 
    ''' This actually creates the ViewModel and returns it via its request class.
    ''' </summary>
    <ExportRequestHandler(EndpointNames.CreateCustomTypeEditorVM)>
    Friend Class CreateCustomTypeEditorVMHandler
        Inherits RequestHandler(Of CreateCustomTypeEditorVMRequest, CreateCustomTypeEditorVMResponse)

        Public Overrides Function HandleRequest(ByVal request As CreateCustomTypeEditorVMRequest) As CreateCustomTypeEditorVMResponse
            ' Gets the respective DesignerHost of the sessionId, which has been passed by the client.
            Dim designerHost = GetDesignerHost(request.SessionId)

            ' Creates the ViewModel and passes the DesignerHost.
            Dim viewModel = CreateViewModel(Of CustomTypeEditorVM)(designerHost)

            ' The ViewModel then initializes and wraps itself into the response class
            ' so it can be returned to the client.
            Return viewModel.Initialize(request.CustomControlProxy)
        End Function
    End Class
End Namespace
