using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using RootDesignerDemo;

namespace SampleRootDesigner
{
    [ToolboxItemFilter(ToolboxCategory, ToolboxItemFilterType.Require)]
    public partial class ShapeRootDesigner : ComponentDesigner, IRootDesigner, IToolboxUser
    {
        private const string ToolboxCategory = "ShapeRootDesigner";
        private const string VsOutputWindowPaneName = "Root Designer Demo";

        private VsOutputWindowLogger _vsOutputWindowLogger = new VsOutputWindowLogger(VsOutputWindowPaneName);
        
        // Member field of custom type RootDesignerView, a control that 
        // will be shown in the Forms designer view. This member is 
        // cached to reduce processing needed to recreate the 
        // view control on each call to GetView().
        private RootDesignerView _designerSurface;

        private IToolboxService _toolboxService = null;
        private ToolboxItemCollection _tools;
        private ISelectionService _selectionService = null;
        private IDesignerHost _designerHost = null;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _vsOutputWindowLogger.WriteLine($"ShapeRootDesigner.Initialize() for component {component.GetType().FullName} called.");
            _selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (!(_selectionService is null))
            {
                _vsOutputWindowLogger.WriteLine($"ShapeRootDesigner.Initialize(): ISelectionService retrieved.");
            }

            _designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (!(_designerHost is null))
            {
                _vsOutputWindowLogger.WriteLine($"ShapeRootDesigner.Initialize(): IDesignerHost retrieved.");
            }

            _toolboxService = GetService(typeof(IToolboxService)) as IToolboxService;
            if (!(_toolboxService is null))
            {
                _vsOutputWindowLogger.WriteLine($"ShapeRootDesigner.Initialize(): IToolboxService retrieved.");
            }
        }

        public ViewTechnology[] SupportedTechnologies => new[] { ViewTechnology.Default };

        public bool GetToolSupported(ToolboxItem tool)
        {
            return !(tool.Properties[ToolboxCategory] is null);
        }

        public void ToolPicked(ToolboxItem tool)
        {
            _vsOutputWindowLogger.WriteLine($"ToolPicked: {tool}");
        }

        // This method returns an instance of the view for this root
        // designer. The "view" is the user interface that is presented
        // in a document window for the user to manipulate. 
        object IRootDesigner.GetView(ViewTechnology technology)
        {
            if (technology != ViewTechnology.Default)
            {
                throw new ArgumentException("Not a supported view technology", "technology");
            }
            
            if (_designerSurface == null)
            {
                // Some type of displayable Form or control is required 
                // for a root designer that overrides GetView(). In this 
                // example, a Control of type RootDesignerView is used.
                // Any class that inherits from Control will work.
                _designerSurface = new RootDesignerView(this);

                _toolboxService = (IToolboxService)this.GetService(typeof(IToolboxService));
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

            return _designerSurface;
        }

        private void SetupToolboxItems()
        {
            CreateToolboxItem("Line Tool", "LineTool", "ShapeRootDesigner",
                RootDesignerDemo.Properties.Resources.Line);
            CreateToolboxItem("Rectangle Tool", "RectangleTool", "ShapeRootDesigner", 
                RootDesignerDemo.Properties.Resources.Rectangle);
            CreateToolboxItem("Text Tool", "TextTool", "ShapeRootDesigner",
                RootDesignerDemo.Properties.Resources.Text);
        }

        private void CreateToolboxItem(string toolDisplayName, string toolTypeName, string toolboxFilterString, Bitmap toolboxBitmap)
        {
            ToolboxItem toolboxItem;
            ToolboxItemFilterAttribute toolboxItemFilterAttribute;
            ToolboxItemFilterAttribute[] toolboxItemFilterAttributeArray;

            string toolboxItemName =$"{ToolboxCategory}.{toolTypeName}";

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

        internal IToolboxService ToolboxService => _toolboxService;
        internal IDesignerHost DesignerHost => _designerHost;
        internal ISelectionService SelectionService => _selectionService;
        internal VsOutputWindowLogger VsOutputWindowLogger => _vsOutputWindowLogger;
    }
}
