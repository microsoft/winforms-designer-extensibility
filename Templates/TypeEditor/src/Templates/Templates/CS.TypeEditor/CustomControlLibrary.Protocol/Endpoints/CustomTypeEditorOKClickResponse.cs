using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Protocol.Endpoints
{
    /// <summary>
    ///  Response class for this endpoint. This is not returning any relevant data, but this class is still needed
    ///  to meet the infrastructure conventions.
    /// </summary>
    public class CustomTypeEditorOKClickResponse : Response.Empty
    {
        public static new CustomTypeEditorOKClickResponse Empty { get; } = new CustomTypeEditorOKClickResponse();

        private CustomTypeEditorOKClickResponse()
        {
        }

        public CustomTypeEditorOKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}
