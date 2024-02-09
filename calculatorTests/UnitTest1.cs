using System;
using Xunit;

public class ConverterTests
{
    [Theory]
    [InlineData(3, "-cm", 7.62)]
    [InlineData(56, "-m", 1.4224)]
    [InlineData(100, "-mm", 2540)]
    public void TestConvertTo(double inches, string unit, double expected)
    {
        // Act
        double result = Converter.ConvertTo(inches, unit);

        // Assert
        Assert.Equal(expected, result, 2);
    }

    [Fact]
    public void TestInvalidUnit()
    {
        // Arrange
        double inches = 5;
        string unit = "-km";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Converter.ConvertTo(inches, unit));
    }
}
