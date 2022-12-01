using System.Collections.Generic;
using Microsoft.DotNet.DesignTools.TypeRouting;

namespace CustomControlLibrary.Designer.Server
{
    /// <summary>
    ///  Class holding the TypeRoutings for resolving the control designer type on the server.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(CustomControlDesigner),
                    typeof(CustomControlDesigner))
            };
    }
}
