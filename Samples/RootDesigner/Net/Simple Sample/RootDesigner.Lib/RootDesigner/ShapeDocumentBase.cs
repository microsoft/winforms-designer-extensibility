using System.ComponentModel;
using System.ComponentModel.Design;

namespace RootDesignerDemo;

// The following attribute associates the SampleRootDesigner designer 
// with the SampleComponent component.
[Designer(typeof(ShapeRootDesigner), typeof(IRootDesigner)),
 ToolboxItem(false)]
public class ShapeDocumentBase : Component
{
    public ShapeDocumentBase()
    {
    }

    private void InitializeComponent()
    {
    }
}
