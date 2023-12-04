using System.Collections.Generic;
using Microsoft.DotNet.DesignTools.TypeRouting;

namespace RootDesignerDemo.Designer.Server
{
    /// <summary>
    ///  Class holding the TypeRoutings for resolving the control designer type on the server.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
        {
            return new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(RdControlDesigner),
                    typeof(RdControlDesigner)),

                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(ShapeRootDesigner),
                    typeof(ShapeRootDesigner))
            };

        }
    }
}
