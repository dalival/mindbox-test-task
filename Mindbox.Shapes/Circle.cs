namespace Mindbox.Shapes;

public class Circle : IFlatShape
{
    public double Radius { get; }

    public double Area { get; }

    public double Perimeter { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than 0.");
        }

        Radius = radius;

        Area = Math.PI * Radius * Radius;
        Perimeter = 2 * Math.PI * Radius;
    }
}
