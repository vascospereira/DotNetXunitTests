using System;
using System.Collections.Generic;
using Xunit;

namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        private static IEnumerable<object[]> Values => new List<object[]>
        {
            new object[] {4, 3, 7},
            new object[] {21, 5.25, 26.25},
            new object[] { double.MaxValue, 1, double.MaxValue }
        };

        private static IEnumerable<object[]> GetValuesToCalculate() => Values;

        /**
         * What if you don't want to create an extra class?
         * For these situations, you can use the [MemberData] attribute => See DataGeneratorTests too
         * Loading data from a property on the test class
         */
        [Theory]
        [MemberData(nameof(GetValuesToCalculate))]
        public void Add_ShouldCalculateValues(double x, double y, double expected)
        {
            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(12.8, 5.56, 71.168)]
        public void Multiply_ShouldCalculateValues(double x, double y, double expected)
        {
            // Act
            double actual = Calculator.Multiply(x, y);

            // Set precision 
            double actualRounded = Math.Round(actual, 10);

            // Assert
            Assert.Equal(expected, actualRounded);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        [InlineData(18.8, 4.7, 4)]
        [InlineData(25.2, 6.4, 3.9375)]
        [InlineData(25.7, 8.7, 2.954022988505747)]
        public void Divide_ShouldCalculateValues(double x, double y, double expected)
        {
            // Act
            double actual = Calculator.Divide(x, y);

            // Set precision
            double actualRounded = Math.Round(actual, 15);

            // Assert
            Assert.Equal(expected, actualRounded);
        }

        [Theory]
        [InlineData(10, 7, 3)]
        [InlineData(18.8, 4.7, 14.1)]
        [InlineData(25.2, -6.4, 31.6)]
        public void Subtract_ShouldCalculateValues(double x, double y, double expected)
        {
            // Act
            double actual = Calculator.Subtract(x, y);

            // Set precision
            double actualRounded = Math.Round(actual, 1);

            // Assert
            Assert.Equal(expected, actualRounded);
        }

        [Fact]
        public void Divide_DivideByZero()
        {
            // Arrange
            const double expected = 0;

            // Act
            double actual = Calculator.Divide(15, 0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
