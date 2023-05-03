using System.ComponentModel;

namespace RootDesignerDemo.ShapeComponents;

public partial class SimpleBoxComponent : Component
{
    public SimpleBoxComponent()
    {
        InitializeComponent();
    }

    public SimpleBoxComponent(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
}
