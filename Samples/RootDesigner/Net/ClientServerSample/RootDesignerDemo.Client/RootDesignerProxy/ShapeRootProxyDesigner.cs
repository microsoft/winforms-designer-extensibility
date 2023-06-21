using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Microsoft.DotNet.DesignTools.Client.Designers;

namespace RootDesignerDemo.Client.RootDesignerProxy
{
    [ToolboxItemFilter(ToolboxCategory, ToolboxItemFilterType.Require)]
    public class ShapeRootProxyDesigner : RootComponentProxyDesigner, IToolboxUser
    {
        private const string ToolboxCategory = "SdkShapeRootDesigner";

        private IToolboxService? _toolboxService = null;
        private ToolboxItemCollection? _tools;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            _toolboxService = (IToolboxService?) GetService(typeof(IToolboxService));
        }

        private void SetupToolboxItems()
        {
            CreateToolboxItem("Line Tool", "LineTool", ToolboxCategory,
                RootDesignerDemo.Client.Properties.Resources.Line);
            CreateToolboxItem("Rectangle Tool", "RectangleTool", ToolboxCategory,
                RootDesignerDemo.Client.Properties.Resources.Rectangle);
            CreateToolboxItem("Text Tool", "TextTool", ToolboxCategory,
                RootDesignerDemo.Client.Properties.Resources.Text);
        }
 
        private void CreateToolboxItem(string toolDisplayName, string toolTypeName, string toolboxFilterString, Bitmap toolboxBitmap)
        {
            ToolboxItem toolboxItem;
            ToolboxItemFilterAttribute toolboxItemFilterAttribute;
            ToolboxItemFilterAttribute[] toolboxItemFilterAttributeArray;

            string toolboxItemName = $"{ToolboxCategory}.{toolTypeName}";

            foreach (ToolboxItem existingToolboxItem in _toolboxService.GetToolboxItems(ToolboxCategory))
            {
                if (existingToolboxItem.TypeName != toolboxItemName)
                {
                    continue;
                }

                // We found the item, so remove it...
                _toolboxService.RemoveToolboxItem(existingToolboxItem);
                break;
            }

            // ...and add it again.
            toolboxItem = new ToolboxItem()
            {
                TypeName = toolboxItemName,
                DisplayName = toolDisplayName,
                Description = $"Description of {toolDisplayName}",
                Bitmap = toolboxBitmap
            };

            toolboxItemFilterAttribute = new ToolboxItemFilterAttribute(toolboxFilterString, ToolboxItemFilterType.Require);
            toolboxItemFilterAttributeArray = new ToolboxItemFilterAttribute[] { toolboxItemFilterAttribute };
            toolboxItem.Filter = (ICollection)toolboxItemFilterAttributeArray;
            toolboxItem.Properties[ToolboxCategory] = toolTypeName;
            _toolboxService.AddToolboxItem(toolboxItem, ToolboxCategory);

            return;
        }

        bool IToolboxUser.GetToolSupported(ToolboxItem tool)
        {
            return !(tool.Properties[ToolboxCategory] is null);
        }

        void IToolboxUser.ToolPicked(ToolboxItem tool)
        {
        }

        protected override void OnAfterGetView()
        {
            // If an IToolboxService was located, update the 
            // category list.
            if (_toolboxService is null)
            {
                MessageBox.Show("Couldn't retrieve Toolbox Service!");
            }
            else
            {
                SetupToolboxItems();
            }
        }
    }
}
