namespace RootDesignerDemo.Designer.Server;

public class EllipseShape : ShapeBase
{
    public override void Render(Graphics g)
        => g.DrawEllipse(CurrentPen, new Rectangle(Location, Size));
}
