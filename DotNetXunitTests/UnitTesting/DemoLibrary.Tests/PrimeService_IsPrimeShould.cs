using Xunit;

namespace DemoLibrary.Tests
{
    public class PrimeServiceIsPrimeShould
    {
        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = PrimeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = PrimeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime.");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void ReturnTrueGivenPrimesLessThan10(int value)
        {
            var result = PrimeService.IsPrime(value);

            Assert.True(result, $"{value} should be prime.");
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void ReturnFalseGivenNonPrimesLessThan10(int value)
        {
            var result = PrimeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}
