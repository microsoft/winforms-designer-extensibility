namespace RootDesignerDemo.Designer.Server;

public class RectangleShape : ShapeBase
{
    public override void Render(Graphics g)
        => g.DrawRectangle(CurrentPen, new Rectangle(Location, Size));
}
