using DemoLibrary.Models;
using System.Collections.Generic;

namespace DemoLibrary
{
    public class PersonDataGenerator
    {
        public static IEnumerable<object[]> GetPersonModelData()
        {
            yield return new object[]
            {
                new PersonModel { FirstName = "Brian", LastName = "Kerningham", Age = 76 },
                new PersonModel { FirstName = "Linus", LastName = "Torvalds", Age = 48 },
                new PersonModel { FirstName = "Ken", LastName = "Thompson", Age = 75 }
            };
            yield return new object[]
            {
                new PersonModel { FirstName = "Bill", LastName = "Gates", Age = 62 },
                new PersonModel { FirstName = "Larry", LastName = "Page", Age = 45 }
            };
        }
    }
}
