// Note: Here we have a 2nd lookup table that works in reverse for server-side operations:
// This table is essential when the server needs to call a Type-Editor for a control.
// In this scenario, the UI runs within the context of Visual Studio, not the server.
// The type routing for this is defined on the client-side because the Type-Editor should
// only exist there, matching the target framework of Visual Studio.
// So, when the server needs the Type-Editor, it asks the client-side,
// "Give me the editor type for control X." The client uses this lookup table to find
// the correct editor type. This way, the server requests what editor type to use,
// even though that type only exists in the Visual Studio context.

using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;
using WinForms.Tiles.Designer.Protocol;

namespace WinForms.Tiles.Designer.Client
{
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
        {
            return new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor, 
                    nameof(EditorNames.TemplateAssignmentEditor), 
                    typeof(TemplateAssignmentEditor)),
            };
        }
    }
}
