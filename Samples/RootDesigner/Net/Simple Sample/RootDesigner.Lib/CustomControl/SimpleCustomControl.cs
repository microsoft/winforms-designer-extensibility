using System.ComponentModel;
using RootDesignerDemo.Design;

namespace RootDesignerDemo;

[Designer(typeof(SimpleCustomControlDesigner))]
public class SimpleCustomControl : Panel
{
    public bool SampleProperty { get; set; }
}
