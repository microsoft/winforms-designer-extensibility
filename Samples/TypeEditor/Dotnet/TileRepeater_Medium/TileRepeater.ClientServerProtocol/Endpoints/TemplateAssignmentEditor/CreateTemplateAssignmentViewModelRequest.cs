using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class CreateTemplateAssignmentViewModelRequest : Request
    {
        public SessionId SessionId { get; private set; }
        public object? TileRepeaterProxy { get; private set; }

        public CreateTemplateAssignmentViewModelRequest() { }

        public CreateTemplateAssignmentViewModelRequest(SessionId sessionId, object? templateAssignmentProxy)
        {
            SessionId = sessionId.IsNull ? throw new ArgumentNullException(nameof(sessionId)) : sessionId;
            TileRepeaterProxy = templateAssignmentProxy;
        }

        public CreateTemplateAssignmentViewModelRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            SessionId = reader.ReadSessionId(nameof(SessionId));
            TileRepeaterProxy = reader.ReadObject(nameof(TileRepeaterProxy));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SessionId), SessionId);
            writer.WriteObject(nameof(TileRepeaterProxy), TileRepeaterProxy);
        }
    }
}
