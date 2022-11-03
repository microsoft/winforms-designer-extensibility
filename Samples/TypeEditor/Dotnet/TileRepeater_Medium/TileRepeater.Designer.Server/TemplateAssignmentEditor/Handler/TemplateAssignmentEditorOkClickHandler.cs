using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.TemplateAssignmentEditorOKClick)]
    internal class TemplateAssignmentEditorOkClickHandler : RequestHandler<TemplateAssignmentEditorOKClickRequest, TemplateAssignmentEditorOKClickResponse>
    {
        public override TemplateAssignmentEditorOKClickResponse HandleRequest(TemplateAssignmentEditorOKClickRequest request)
        {
            var viewModel = (TemplateAssignmentViewModel)request.ViewModel;
            viewModel.OKClick();

            return TemplateAssignmentEditorOKClickResponse.Empty;
        }
    }
}
