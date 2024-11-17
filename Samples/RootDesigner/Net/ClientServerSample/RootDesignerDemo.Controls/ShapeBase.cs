using System.ComponentModel;

namespace RootDesignerDemo.Designer.Server;

public class ShapeBase : Component
{
    public ShapeBase()
    {
        CurrentPen = Pens.DarkBlue;
        CurrentBrush = (SolidBrush)Brushes.DarkBlue;
        Location = DefaultLocation;
    }

    public static Point DefaultLocation => new Point(20, 20);
    public static Size DefaultSize => new Size(40, 40);

    protected Pen CurrentPen { get; }
    protected SolidBrush CurrentBrush { get; }

    public Point Location { get; set; }
    public Size Size { get; set; }

    public Color PenColor
    {
        get => CurrentPen.Color;

        set
        {
            if (CurrentPen.Color == value)
            {
                return;
            }

            CurrentPen.Color = value;
        }
    }

    public Color FillColor
    {
        get => CurrentBrush.Color;

        set
        {
            if (CurrentBrush.Color == value)
            {
                return;
            }

            CurrentBrush.Color = value;
        }
    }

    public virtual void Render(Graphics g) { }
}
