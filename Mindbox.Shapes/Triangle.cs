namespace Mindbox.Shapes;

public class Triangle : IFlatShape
{
    public double SideOne { get; }

    public double SideTwo { get; }

    public double SideThree { get; }

    public double Area { get; }

    public bool IsRight { get; }

    public double Perimeter => SideOne + SideTwo + SideThree;

    public Triangle(double sideOne, double sideTwo, double sideThree)
    {
        ThrowIfInvalidArguments(sideOne, sideTwo, sideThree);

        SideOne = sideOne;
        SideTwo = sideTwo;
        SideThree = sideThree;

        Area = CalculateArea();
        IsRight = IsTriangleRight();
    }

    private double CalculateArea()
    {
        var p = Perimeter / 2;
        var s = Math.Sqrt(p * (p - SideOne) * (p - SideTwo) * (p - SideThree));

        return s;
    }

    private bool IsTriangleRight()
    {
        var sides = new List<double> { SideOne, SideTwo, SideThree };
        sides.Sort();

        var hypotenuseSqr = sides[2] * sides[2];
        var adjacentSqr = sides[1] * sides[1];
        var oppositeSqr = sides[0] * sides[0];

        const double tolerance = 0.0000000001;

        return Math.Abs(hypotenuseSqr - adjacentSqr - oppositeSqr) < tolerance;
    }

    private void ThrowIfInvalidArguments(double sideOne, double sideTwo, double sideThree)
    {
        if (sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
        {
            throw new ArgumentOutOfRangeException("Side lengths must be greater than 0.");
        }

        if (sideOne + sideTwo <= sideThree
            || sideOne + sideThree <= sideTwo
            || sideTwo + sideThree <= sideOne)
        {
            throw new ArgumentException("Invalid side lengths. The sum of the two sides must be greater than the third side.");
        }
    }
}
