namespace Mindbox.Shapes.Tests;

public class TriangleTests
{
    public static IEnumerable<object[]> GetRandomSides(int count)
    {
        var random = Random.Shared;

        for (var i = 0; i < count; i++)
        {
            // Generate random side lengths between 1 and 10
            var sideOne = random.NextDouble() * 9 + 1;
            var sideTwo = random.NextDouble() * (10 - sideOne) + 1;
            var sideThree = 10 - sideOne - sideTwo;

            yield return new object[] { sideOne, sideTwo, sideThree };
        }
    }

    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(0, 1, 1)]
    public void Constructor_SideIsOutOfRange_ThrowsException(double sideOne, double sideTwo, double sideThree)
    {
        Assert.Throws<ArgumentOutOfRangeException>( () => new Triangle(sideOne, sideTwo, sideThree));
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(3, 1, 1)]
    public void Constructor_ImpossibleToCreateTriangleOfSuchSides_ThrowsException(double sideOne, double sideTwo, double sideThree)
    {
        Assert.Throws<ArgumentException>( () => new Triangle(sideOne, sideTwo, sideThree));
    }

    [Theory]
    [InlineData(7, 5, 3)]
    [InlineData(7, 5, 2.0000000001)]
    public void Constructor_ValidSides_DoesNotThrowException(double sideOne, double sideTwo, double sideThree)
    {
        var exception = Record.Exception(() => new Triangle(sideOne, sideTwo, sideThree));
        Assert.Null(exception);
    }

    [Fact]
    public void Area_ReturnsCorrectValue()
    {
        // Arrange
        const double a = 3.0123456789;
        const double b = 5.0123456789;
        const double c = 7.0123456789;
        const double p = (a + b + c) / 2;
        var expectedArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        var triangle = new Triangle(a, b, c);

        // Act
        var area = triangle.Area;

        // Assert
        Assert.Equal(expectedArea, area, precision: 10);
    }

    [Fact]
    public void Perimeter_ReturnsCorrectValue()
    {
        // Arrange
        const double a = 3.0123456789;
        const double b = 5.0123456789;
        const double c = 7.0123456789;
        const double expectedPerimeter = a + b + c;
        var triangle = new Triangle(a, b, c);

        // Act
        var perimeter = triangle.Perimeter;

        // Assert
        Assert.Equal(expectedPerimeter, perimeter, precision: 10);
    }

    [Theory]
    [InlineData(7, 5, 3, false)]
    [InlineData(5, 4, 3, true)]
    [InlineData(5 * 1.0123456789, 4 * 1.0123456789, 3 * 1.0123456789, true)]
    public void IsRight_ReturnsCorrectValue(double sideOne, double sideTwo, double sideThree, bool expectedResult)
    {
        // Arrange
        var triangle = new Triangle(sideOne, sideTwo, sideThree);

        // Act
        var result = triangle.IsRight;

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
