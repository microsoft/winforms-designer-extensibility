using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class TemplateAssignmentEditorOKClickResponse : Response.Empty
    {
        public static new TemplateAssignmentEditorOKClickResponse Empty { get; } = new TemplateAssignmentEditorOKClickResponse();

        private TemplateAssignmentEditorOKClickResponse()
        {
        }

        public TemplateAssignmentEditorOKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}
