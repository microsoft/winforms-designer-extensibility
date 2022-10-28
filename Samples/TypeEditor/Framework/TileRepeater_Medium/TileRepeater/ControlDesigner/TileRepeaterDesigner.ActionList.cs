using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;

namespace WinForms.Tiles.Designer
{
    internal partial class TileRepeaterDesigner
    {
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);
            private const string Data = nameof(Data);

            private readonly ComponentDesigner _designer;

            public ActionList(TileRepeaterDesigner designer)
                : base(designer.Component)
            {
                _designer = designer;
            }

            public bool AutoLayoutOnResize
            {
                get => ((TileRepeater)Component!).AutoLayoutOnResize;

                // This won't work, since the PropertyBrowser wouldn't get updated.
                // set => ((TileRepeater)Component!).AutoLayoutOnResize = value;

                // Do this instead:
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(AutoLayoutOnResize)]!
                        .SetValue(Component, value);
            }

            [AttributeProvider(typeof(IListSource))]
            public object? DataSource
            {
                get => ((TileRepeater)Component!).DataSource;
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(DataSource)]!
                        .SetValue(Component, value);
            }

            public void InvokeItemTemplateDialog()
                => InvokePropertyEditor(nameof(TileRepeater.ItemTemplate));

            public void InvokeSeparatorTemplateDialog()
                => InvokePropertyEditor(nameof(TileRepeater.SeparatorTemplate));

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));
                actionItems.Add(new DesignerActionHeaderItem(Data));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(AutoLayoutOnResize),
                    "Automatic layout on resize",
                    Behavior,
                    "Determines, that the tiles get layouted automatically, when the TileRepeater gets resized."));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(DataSource),
                    "DataSource",
                    Data,
                    "Sets the collection with the DataSource types which maps and bind to the TileContent UserControls at runtime."));

                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeItemTemplateDialog),
                    "Edit item template assignments...",
                    true));

                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeSeparatorTemplateDialog),
                    "Edit separator template assignments...",
                    true));

                return actionItems;
            }

            private void InvokePropertyEditor(string PropertyName)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();

                var property = TypeDescriptor.GetProperties(Component)[PropertyName];
                var typeDescriptor = new TypeDescriptorContext(Component, property);

                var editor = (UITypeEditor)property.GetEditor(typeof(UITypeEditor));
                var value = property.GetValue(Component);
                var newValue = editor.EditValue(typeDescriptor, value);

                if (!Equals(newValue, value))
                {
                    property.SetValue(Component, newValue);
                }
            }
        }
    }
}
