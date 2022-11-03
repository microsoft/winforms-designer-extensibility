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
            var designerHost = GetDesignerHost(request.SessionId);

            var viewModel = CreateViewModel<TemplateAssignmentViewModel>(designerHost);

            return viewModel.Initialize(request.TileRepeaterProxy!);
        }
    }
}
