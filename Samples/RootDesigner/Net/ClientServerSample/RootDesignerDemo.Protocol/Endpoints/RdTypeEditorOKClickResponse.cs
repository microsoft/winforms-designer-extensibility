using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Response class for this endpoint. This is not returning any relevant data, but this class is still needed
    ///  to meet the infrastructure conventions.
    /// </summary>
    public class RdTypeEditorOKClickResponse : Response.Empty
    {
        public static new RdTypeEditorOKClickResponse Empty { get; } = new RdTypeEditorOKClickResponse();

        private RdTypeEditorOKClickResponse()
        {
        }

        public RdTypeEditorOKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}
