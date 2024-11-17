using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.DotNet.DesignTools.Designers;

namespace RootDesignerDemo;

[ToolboxItemFilter(ToolboxCategory, ToolboxItemFilterType.Require)]
public partial class ShapeRootDesigner : ComponentDesigner, IRootDesigner //, IToolboxUser
{
    private const string ToolboxCategory = "ShapeRootDesigner";
    
    // Member field of custom type RootDesignerView, a control that 
    // will be shown in the Forms designer view. This member is 
    // cached to reduce processing needed to recreate the 
    // view control on each call to GetView().
    private RootDesignerView? _designerSurface;

    //private IToolboxService? _toolboxService = null;
    //private ToolboxItemCollection? _tools;

    public ViewTechnology[] SupportedTechnologies => new[] { ViewTechnology.Default };

    //public bool GetToolSupported(ToolboxItem tool)
    //{
    //    return !(tool.Properties[ToolboxCategory] is null);
    //}

    //public void ToolPicked(ToolboxItem tool)
    //{
    //    // TODO: Add the code, which adds a new shape to the designer surface.
    //}

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
            _designerSurface = new SampleRootDesignerView(this);

            //_toolboxService = (IToolboxService)this.GetService(typeof(IToolboxService));
            //// If an IToolboxService was located, update the 
            //// category list.
            //if (_toolboxService is null)
            //{
            //    MessageBox.Show("Couldn't retrieve Toolbox Service!");
            //}
            //else
            //{
            //    SetupToolboxItems();
            //}
        }

        return _designerSurface;
    }

    //private void SetupToolboxItems()
    //{
    //    CreateToolboxItem("Line Tool", "LineTool", "ShapeRootDesigner",
    //        RootDesignerDemo.Properties.Resources.Rectangle);
    //    CreateToolboxItem("Rectangle Tool", "RectangleTool", "ShapeRootDesigner", 
    //        RootDesignerDemo.Properties.Resources.Rectangle);
    //    CreateToolboxItem("Text Tool", "TextTool", "ShapeRootDesigner",
    //        RootDesignerDemo.Properties.Resources.Rectangle);
    //}

    private void CreateToolboxItem(string toolDisplayName, string toolTypeName, string toolboxFilterString, Bitmap toolboxBitmap)
    {
        //ToolboxItem toolboxItem;
        //ToolboxItemFilterAttribute toolboxItemFilterAttribute;
        //ToolboxItemFilterAttribute[] toolboxItemFilterAttributeArray;

        //string toolboxItemName =$"{ToolboxCategory}.{toolTypeName}";

        //foreach (ToolboxItem existingToolboxItem in _toolboxService.GetToolboxItems(ToolboxCategory))
        //{
        //    if (existingToolboxItem.TypeName != toolboxItemName)
        //    {
        //        continue;
        //    }

        //    // We found the item, so remove it...
        //    _toolboxService.RemoveToolboxItem(existingToolboxItem);
        //    break;
        //}

        //// ...and add it again.
        //toolboxItem = new ToolboxItem()
        //{
        //    TypeName = toolboxItemName,
        //    DisplayName = toolDisplayName,
        //    Description = $"Description of {toolDisplayName}",
        //    Bitmap = toolboxBitmap
        //};

        //toolboxItemFilterAttribute = new ToolboxItemFilterAttribute(toolboxFilterString, ToolboxItemFilterType.Require);
        //toolboxItemFilterAttributeArray = new ToolboxItemFilterAttribute[] { toolboxItemFilterAttribute };
        //toolboxItem.Filter = (ICollection)toolboxItemFilterAttributeArray;
        //toolboxItem.Properties[ToolboxCategory] = toolTypeName;
        //_toolboxService.AddToolboxItem(toolboxItem, ToolboxCategory);

        return;
    }
}
