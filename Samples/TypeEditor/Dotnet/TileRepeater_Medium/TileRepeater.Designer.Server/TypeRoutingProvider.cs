// Note: We need the server-side TypeRoutingProvider to enable type resolution for the designer
// in Visual Studio (client-side). On the client-side, we identify the designer for each control
// that the root designer (the designer of the Form or UserControl) is hosting.
// On the client-side, this will be a ComponentProxy, not the actual custom control,
// since the real control resides on the server-side, as does its designer.
// Therefore, on the client-side, we only know the type as a string; the actual type doesn't exist.
// This provider links the name to the actual type. The name "TileRepeater" is atop our control.
// Since it's a string and not a real type, we can read it on the client-side but not fully understand it.
// We can, however, ask the server to "give us the ProxyObject for the designer named 'TileRepeaterDesigner'."
// The server then uses a lookup table, finds the actual type, creates an ObjectProxy,
// and returns a type descriptor with that proxy (pointing to the real type on the server) back to
// the client-side designer.

using Microsoft.DotNet.DesignTools.TypeRouting;
using System.Collections.Generic;

namespace WinForms.Tiles.Designer.Server
{
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(TileRepeaterDesigner),
                    typeof(TileRepeaterDesigner))
            };
    }
}
