using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Endpoint to handle the event when the user clicks the OK button of the custom type editor.
    /// </summary>
    [Shared]
    [ExportEndpoint]
    public class RdTypeEditorOKClickEndpoint : Endpoint<RdTypeEditorOKClickRequest, RdTypeEditorOKClickResponse>
    {
        public override string Name => EndpointNames.RdTypeEditorEditorOKClick;

        protected override RdTypeEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override RdTypeEditorOKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}
