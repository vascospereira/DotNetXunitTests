using System.Collections;
using System.Collections.Generic;

namespace DemoLibrary
{
    public class PrimeDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 13, 17, 31, 97 };
            yield return new object[] { 173, 199 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static IEnumerable<object[]> GetNonPrimeNumbers => new List<object[]>
        {
            new object[] {10, 18, 96},
            new object[] {174, 220, 534, 826}
        };
    }
}
