using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Protocol.Endpoints
{
    /// <summary>
    ///  Request class for the <see cref="CreateCustomTypeEditorVMEndpoint"/>. This passes the necessary
    ///  context  (SessionId, proxy of the CustomControl) from the client to the server.
    /// </summary>
    public class CreateCustomTypeEditorVMRequest : Request
    {
        public SessionId SessionId { get; private set; }
        public object? CustomControlProxy { get; private set; }

        public CreateCustomTypeEditorVMRequest() { }

        public CreateCustomTypeEditorVMRequest(SessionId sessionId, object? customControlProxy)
        {
            SessionId = sessionId.OrThrowIfArgumentIsNull();
            CustomControlProxy = customControlProxy;
        }

        public CreateCustomTypeEditorVMRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            SessionId = reader.ReadSessionId(nameof(SessionId));
            CustomControlProxy = reader.ReadObject(nameof(CustomControlProxy));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SessionId), SessionId);
            writer.WriteObject(nameof(CustomControlProxy), CustomControlProxy);
        }
    }
}
