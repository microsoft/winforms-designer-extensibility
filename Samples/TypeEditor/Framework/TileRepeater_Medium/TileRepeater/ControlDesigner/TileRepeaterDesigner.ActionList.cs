using System;
using System.ComponentModel;
using System.ComponentModel.Design;
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
                => _designer.InvokePropertyEditor(nameof(TileRepeater.ItemTemplate));

            public void InvokeSeparatorTemplateDialog()
                => _designer.InvokePropertyEditor(nameof(TileRepeater.SeparatorTemplate));

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
        }
    }

    public static class ComponentDesignerExtension
    {
        public static void InvokePropertyEditor(this ComponentDesigner componentDesigner, string PropertyName)
        {
            if (!(componentDesigner?.Component?.Site is { } site))
            {
                throw new NullReferenceException($"ComponentDesigner's component or component's site is null.");
            }

            IComponent component = componentDesigner.Component;
            IServiceProvider serviceProvider = site;

            var property = TypeDescriptor.GetProperties(component)[PropertyName];
            if (property is not null)
            {
                var editor = property.GetEditor(typeof(UITypeEditor)) as UITypeEditor;
                if (editor is not null)
                {
                    var value = property.GetValue(component);
                    var newValue = editor.EditValue(site, value);

                    if (!Equals(newValue, value))
                    {
                        property.SetValue(component, newValue);
                    }
                }
            }
        }
    }
}
