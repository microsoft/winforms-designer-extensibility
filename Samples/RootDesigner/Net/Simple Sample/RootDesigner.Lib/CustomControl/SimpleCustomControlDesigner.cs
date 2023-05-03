using Microsoft.DotNet.DesignTools.Designers.Actions;
using Microsoft.DotNet.DesignTools.Designers;

using System.ComponentModel;

namespace RootDesignerDemo.Design
{
    /// <summary>
    ///  Control Designer for the <see cref="SimpleTileRepeater" control./>
    /// </summary>
    internal partial class SimpleCustomControlDesigner : ControlDesigner
    {
        /// <summary>
        ///  Hooks up the Action lists.
        /// </summary>
        /// <remarks>
        ///  Action lists for the OOP-Designer can be implemented exactly like for the in-process Designer. The Designer
        ///  has to be compiled though against the Designer SDK, and ActionList related classes must come from the
        ///  <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
        /// </remarks>
        public override DesignerActionListCollection ActionLists
            => new()
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
        }

        /// <summary>
        ///  Action lists implementation for the <see cref="SimpleTileRepeaterDesigner"/>.
        /// </summary>
        /// <remarks>
        ///  Note: Action lists for the OOP-Designer can be implemented exactly like for the in-process Designer. The Designer
        ///  has to be compiled though against the Designer SDK, and ActionList related classes must come from the
        ///  <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
        /// </remarks>
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);
            private const string Data = nameof(Data);

            private readonly ComponentDesigner _designer;

            public ActionList(SimpleCustomControlDesigner designer)
                : base(designer.Component)
            {
                _designer = designer;
            }

            public bool SampleProperty
            {
                get => ((SimpleCustomControl)Component!).SampleProperty;

                // Do this instead:
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(SampleProperty)]!
                        .SetValue(Component, value);
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));
                actionItems.Add(new DesignerActionHeaderItem(Data));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(SampleProperty),
                    "Some Sample Property",
                    Behavior,
                    "A demo property to have something to show for the Action List."));

                return actionItems;
            }
        }
    }
}
