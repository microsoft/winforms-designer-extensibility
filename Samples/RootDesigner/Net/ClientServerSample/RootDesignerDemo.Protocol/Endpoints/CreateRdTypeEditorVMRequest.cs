using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Request class for the <see cref="CreateRdTypeEditorVMEndpoint"/>. This passes the necessary
    ///  context  (SessionId, proxy of the RdControl) from the client to the server.
    /// </summary>
    public class CreateRdTypeEditorVMRequest : Request
    {
        public SessionId SessionId { get; private set; }
        public object? RdControlProxy { get; private set; }

        public CreateRdTypeEditorVMRequest() { }

        public CreateRdTypeEditorVMRequest(SessionId sessionId, object? customControlProxy)
        {
            SessionId = sessionId.OrThrowIfArgumentIsNull();
            RdControlProxy = customControlProxy;
        }

        public CreateRdTypeEditorVMRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            SessionId = reader.ReadSessionId(nameof(SessionId));
            RdControlProxy = reader.ReadObject(nameof(RdControlProxy));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SessionId), SessionId);
            writer.WriteObject(nameof(RdControlProxy), RdControlProxy);
        }
    }
}
