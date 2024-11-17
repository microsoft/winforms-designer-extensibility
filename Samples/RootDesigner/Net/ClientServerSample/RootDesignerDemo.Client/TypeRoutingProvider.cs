using System.Collections.Generic;
using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using RootDesignerDemo.Client.RootDesignerProxy;
using RootDesignerDemo.Designer.Client;
using RootDesignerDemo.Protocol;

namespace RootDesignerDemo.Designer.Server
{
    /// <summary>
    ///  Class holding the TypeRoutings for resolving the control designer type on the client.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
        {
            return new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.RdTypeEditor),
                    typeof(RdTypeEditor)),

                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(DesignerNames.ShapeRootDesigner),
                    typeof(ShapeRootProxyDesigner)),
            };
        }
    }
}
