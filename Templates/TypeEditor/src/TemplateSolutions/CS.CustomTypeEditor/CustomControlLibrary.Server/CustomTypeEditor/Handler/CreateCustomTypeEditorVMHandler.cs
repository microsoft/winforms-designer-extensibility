using CustomControlLibrary.Protocol;
using CustomControlLibrary.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Designer.Server.Handlers
{
    /// <summary>
    /// The handler for <see cref="CreateCustomTypeEditorVMEndpoint"/>. 
    /// This actually creates the ViewModel and returns it via its request class.
    /// </summary>
    [ExportRequestHandler(EndpointNames.CreateCustomTypeEditorVM)]
    internal class CreateCustomTypeEditorVMHandler 
        : RequestHandler<CreateCustomTypeEditorVMRequest, CreateCustomTypeEditorVMResponse>
    {
        public override CreateCustomTypeEditorVMResponse HandleRequest(CreateCustomTypeEditorVMRequest request)
        {
            // Gets the respective DesignerHost of the sessionId, which has been passed by the client.
            var designerHost = GetDesignerHost(request.SessionId);

            // Creates the ViewModel and passes the DesignerHost.
            var viewModel = CreateViewModel<CustomTypeEditorVM>(designerHost);
            
            // The ViewModel then initializes and wraps itself into the response class
            // so it can be returned to the client.
            return viewModel.Initialize(request.CustomControlProxy!);
        }
    }
}
