using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Protocol.Endpoints
{
    /// <summary>
    ///  Endpoint to handle the event when the user clicks the OK button of the custom type editor.
    /// </summary>
    [Shared]
    [ExportEndpoint]
    public class CustomTypeEditorOKClickEndpoint : Endpoint<CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse>
    {
        public override string Name => EndpointNames.CustomTypeEditorEditorOKClick;

        protected override CustomTypeEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CustomTypeEditorOKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}
