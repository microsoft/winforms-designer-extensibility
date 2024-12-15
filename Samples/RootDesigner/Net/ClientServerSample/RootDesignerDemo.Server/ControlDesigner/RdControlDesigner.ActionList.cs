using System.ComponentModel;
using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using RootDesignerDemo.Controls;

namespace RootDesignerDemo.Designer.Server
{
    internal partial class RdControlDesigner
    {
        /// <summary>
        ///  Action lists implementation for the <see cref="RdControl"/>.
        /// </summary>
        /// <remarks>
        ///  Note: Action lists for the out-of-process Designer can be implemented exactly as they would be for the in-process
        ///  Designer, except: The control designer has to be compiled against the Winforms Designer Extensibility SDK, and ActionList
        ///  related classes must come from the <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
        /// </remarks>
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);

            private readonly ComponentDesigner _designer;

            public ActionList(RdControlDesigner designer)
                : base(designer.Component)
            {
                _designer = designer;
            }

            public RdPropertyStore? CustomProperty
            {
                get => ((RdControl?)Component)?.RdPropertyStoreProperty;

                // Note: This code would not work, since the PropertyBrowser wouldn't get updated.
                //set
                //{
                //    if (Component is { } component)
                //    {
                //        ((RdControl)component).CustomProperty = value;
                //    }
                //}

                // Do this instead:
                set
                {
                    if (Component is not null)
                    {
                        TypeDescriptor.GetProperties(Component)[nameof(CustomProperty)]?.SetValue(Component, value);
                    }
                }
            }

            public void InvokeRdTypeEditor()
                => _designer.InvokePropertyEditor(nameof(RdControl.RdPropertyStoreProperty));

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(CustomProperty),
                    "CustomProperty definition",
                    Behavior,
                    "Controls the values of the CustomProperty Definition."));

                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeRdTypeEditor),
                    "Invokes the custom TypeEditor...",
                    true));

                return actionItems;
            }
        }
    }
}
