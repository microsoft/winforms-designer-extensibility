using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.DotNet.DesignTools.Designers;

namespace RootDesignerDemo.Designer.Server;

[ToolboxItemFilter(ToolboxCategory, ToolboxItemFilterType.Require)]
public partial class ShapeRootDesigner : ComponentDesigner, IRootDesigner
{
    private const string ToolboxCategory = "SdkShapeRootDesigner";

    // Member field of custom type RootDesignerView, a control that 
    // will be shown in the Forms designer view. This member is 
    // cached to reduce processing needed to recreate the 
    // view control on each call to GetView().
    private RootDesignerView? _designerSurface;

    public ViewTechnology[] SupportedTechnologies => new[] { ViewTechnology.Default };

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
        }

        return _designerSurface;
    }
}
