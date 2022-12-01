using CustomControlLibrary.Designer.Client;
using CustomControlLibrary.Protocol;
using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;

namespace CustomControlLibrary.Designer.Server
{
    /// <summary>
    ///  Class holding the TypeRoutings for resolving the control designer type on the client.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.CustomTypeEditor),
                    typeof(CustomTypeEditor)),
            };
    }
}
