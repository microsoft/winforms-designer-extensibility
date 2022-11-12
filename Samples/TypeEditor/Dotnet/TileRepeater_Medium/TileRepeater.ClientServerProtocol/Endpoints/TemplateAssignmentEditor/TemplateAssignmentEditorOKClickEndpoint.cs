using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class TemplateAssignmentEditorOKClickEndpoint : Endpoint<TemplateAssignmentEditorOKClickRequest, TemplateAssignmentEditorOKClickResponse>
    {
        public override string Name => EndpointNames.TemplateAssignmentEditorOKClick;

        protected override TemplateAssignmentEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override TemplateAssignmentEditorOKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}
