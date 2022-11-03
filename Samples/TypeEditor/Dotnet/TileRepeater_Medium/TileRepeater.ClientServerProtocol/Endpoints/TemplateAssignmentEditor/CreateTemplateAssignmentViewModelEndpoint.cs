using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class CreateTemplateAssignmentViewModelEndpoint 
        : Endpoint<CreateTemplateAssignmentViewModelRequest, CreateTemplateAssignmentViewModelResponse>
    {
        public override string Name => EndpointNames.CreateTemplateAssignmentViewModel;

        protected override CreateTemplateAssignmentViewModelRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateTemplateAssignmentViewModelResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}
