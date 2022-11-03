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
