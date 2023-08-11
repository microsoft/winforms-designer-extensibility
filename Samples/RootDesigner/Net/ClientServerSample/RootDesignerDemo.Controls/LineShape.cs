namespace RootDesignerDemo.Designer.Server;

public class LineShape : ShapeBase
{
    public override void Render(Graphics g)
        => g.DrawLine(CurrentPen, Location, Location + Size);
}
