using DemoLibrary.Models;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataGeneratorTests
    {
        //The [ClassData] attribute is a convenient way of removing clutter from your test files
        [Theory]
        [ClassData(typeof(PrimeDataGenerator))]
        public void ReturnTruePrimesWithClassDataFromPrimeDataGenerator(params int[] list)
        {
            foreach (int t in list)
            {
                Assert.True(PrimeService.IsPrime(t));
            }
        }

        /**
         * We can use the [MemberData] attribute => See CalculatorTests
         * Can be used to fetch data for a [Theory] from a static property or method of a type
         * Loading data from a property or method on a different class
         */
        [Theory]
        [MemberData(nameof(PrimeDataGenerator.GetNonPrimeNumbers), MemberType = typeof(PrimeDataGenerator))]
        public void AllNumbersAreNotPrimeWithMemberDataFromPrimeDataGenerator(params int[] list)
        {
            foreach (int t in list)
            {
                Assert.False(PrimeService.IsPrime(t));
            }
        }

        [Theory]
        [MemberData(nameof(PersonDataGenerator.GetPersonModelData), MemberType = typeof(PersonDataGenerator))]
        public void AllPersonsAreAbove30WithMemberDataFromPersonDataGenerator(params PersonModel[] list)
        {
            foreach (PersonModel p in list)
            {
                Assert.True(p.Age > 30);
            }
        }
    }
}
