using RootDesignerDemo.Protocol;
using RootDesignerDemo.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Designer.Server.Handlers
{
    /// <summary>
    /// The handler for <see cref="CreateRdTypeEditorVMEndpoint"/>. 
    /// This actually creates the ViewModel and returns it via its request class.
    /// </summary>
    [ExportRequestHandler(EndpointNames.CreateRdTypeEditorVM)]
    internal class CreateRdTypeEditorVMHandler 
        : RequestHandler<CreateRdTypeEditorVMRequest, CreateRdTypeEditorVMResponse>
    {
        public override CreateRdTypeEditorVMResponse HandleRequest(CreateRdTypeEditorVMRequest request)
        {
            // Gets the respective DesignerHost of the sessionId, which has been passed by the client.
            var designerHost = GetDesignerHost(request.SessionId);

            // Creates the ViewModel and passes the DesignerHost.
            var viewModel = CreateViewModel<RdTypeEditorVM>(designerHost);
            
            // The ViewModel then initializes and wraps itself into the response class
            // so it can be returned to the client.
            return viewModel.Initialize(request.RdControlProxy!);
        }
    }
}
