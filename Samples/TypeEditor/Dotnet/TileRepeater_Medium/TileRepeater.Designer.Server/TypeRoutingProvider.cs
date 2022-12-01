// Note: We need a TypeRoutineProvider ONLY in those cases,
// where we need to have User-Interaction direct on the Design Surface and inside the control,
// for example where it is the case with the SplitterControl. In that case, for certain operations,
// we need to have an assignment from the actual control Designer to a ControlDesignerProxy, which would
// do the respective UI-Interaction with the User in the Context of the client.

//using Microsoft.DotNet.DesignTools.TypeRouting;
//using System.Collections.Generic;

//namespace WinForms.Tiles.Designer.Server
//{
//    [ExportTypeRoutingDefinitionProvider]
//    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
//    {
//        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
//            => new[]
//            {
//                new TypeRoutingDefinition(
//                    TypeRoutingKinds.Designer, 
//                    nameof(TileRepeaterDesignerProxy), 
//                    typeof(TileRepeaterDesignerProxy))
//            };
//    }
//}
