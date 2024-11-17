using System.ComponentModel;
using System.ComponentModel.Design;

namespace RootDesignerDemo.Designer.Server;

// The following attribute associates the SampleRootDesigner designer 
// with the SampleComponent component.
[Designer("ShapeRootDesigner", typeof(IRootDesigner)),
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
