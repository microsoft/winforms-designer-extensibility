using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CreateTemplateAssignmentViewModel)]
    internal class CreateTemplateAssignmentViewModelHandler 
        : RequestHandler<CreateTemplateAssignmentViewModelRequest, CreateTemplateAssignmentViewModelResponse>
    {
        public override CreateTemplateAssignmentViewModelResponse HandleRequest(CreateTemplateAssignmentViewModelRequest request)
        {
            // We need the DesignerHost to have the Designer-infrastructure create our server-side view model:
            // We get the DesignerHost for the session that is correlating to the open design document in VS
            // by the session ID:
            var designerHost = GetDesignerHost(request.SessionId);

            // With the designerHost instance, we're now able to have the server-side view model created.
            var viewModel = CreateViewModel<TemplateAssignmentViewModel>(designerHost);

            // The view model now not only creates the list of types we need to show "on the other side";
            // it also creates the necessary response class, which wraps everything - so with this one line,
            // we're returning the server-side viewmodel (as a proxy) and both of the type lists in one go.
            return viewModel.Initialize(request.TileRepeaterProxy!);
        }
    }
}
