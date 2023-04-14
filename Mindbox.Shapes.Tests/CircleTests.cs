namespace Mindbox.Shapes.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Constructor_InvalidRadius_ThrowsException(double radius)
    {
        Assert.Throws<ArgumentOutOfRangeException>( () => new Circle(radius));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0.0000000001)]
    [InlineData(1.23456789E150)]
    public void Constructor_ValidRadius_DoesNotThrowException(double radius)
    {
        var exception = Record.Exception(() => new Circle(radius));
        Assert.Null(exception);
    }

    [Fact]
    public void Area_ReturnsCorrectValue()
    {
        // Arrange
        const double radius = 1234567890.0123456789;
        const double expectedArea = Math.PI * radius * radius;
        var circle = new Circle(radius);

        // Act
        var area = circle.Area;

        // Assert
        Assert.Equal(expectedArea, area, precision: 10);
    }

    [Fact]
    public void Perimeter_ReturnsCorrectValue()
    {
        // Arrange
        const double radius = 1234567890.0123456789;
        const double expectedPerimeter = 2 * Math.PI * radius;
        var circle = new Circle(radius);

        // Act
        var perimeter = circle.Perimeter;

        // Assert
        Assert.Equal(expectedPerimeter, perimeter, precision: 10);
    }
}
