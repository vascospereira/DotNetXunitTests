using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void GetAllPeople_ShouldReturnThePeopleFromFile()
        {
            // Arrange
            List<PersonModel> expected = new List<PersonModel>()
            {
                new PersonModel { FirstName = "Cristiano", LastName = "Ronaldo" },
                new PersonModel { FirstName = "Lionel", LastName = "Messi" },
                new PersonModel { FirstName = "Toni", LastName = "Kross" }
            };

            // Act
            List<PersonModel> actual = DataAccess.GetAllPeople();

            // Assert
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].FirstName, actual[i].FirstName);
            }
        }

        [Theory]
        [InlineData("Cristiano,RonaldoLionel,MessiToni,Kroos")]
        public void ConvertModelsToCsv_ShouldReturnCsvFormat(string expected)
        {
            // Act
            StringBuilder actual = new StringBuilder();
            List<PersonModel> people = DataAccess.GetAllPeople();
            IEnumerable<string> actualList = DataAccess.ConvertModelsToCsv(people);
            foreach (var line in actualList)
            {
                actual.Append(line);
            }

            //Assert
            Assert.Equal(expected, actual.ToString());
        }

        /// <summary>
        /// This test only passes the first time it runs.
        /// people.txt file can only have 3 names otherwise the test fails
        /// </summary>
        /// <param name="filename">InlineData("people.txt")</param>

        [Theory]
        [InlineData("people.txt")]
        public void WriteTextToFile_ShouldWork(string filename)
        {
            // Arrange
            string myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(myDocPath, filename);
            List<PersonModel> actual = DataAccess.GetAllPeople();

            // Act
            DataAccess.WriteTextToFile(actual, path);
            int expected = File.ReadAllLines(path).Length;

            // Assert
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [InlineData("people.txt")]
        public void AppendTextToFile_ShouldWork(string filename)
        {
            // Arrange
            string myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(myDocPath, filename);

            const int actual = 4; // 4 names in the file
            PersonModel person = new PersonModel { FirstName = "Dustin", LastName = "Johnson" };

            // Act
            DataAccess.AppendTextToFile(person, filePath);
            int expected = File.ReadAllLines(filePath).Length;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Lionel", "Messi")]
        public void CheckFullName_ShouldWork(string firstName, string lastName)
        {
            PersonModel actual = new PersonModel { FirstName = firstName, LastName = lastName };
            Assert.Equal($"{firstName} {lastName}", actual.FullName);
        }

        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            // Arrange
            PersonModel firstPerson = new PersonModel { FirstName = "Roger", LastName = "Federer" };
            PersonModel secondPerson = new PersonModel { FirstName = "Tiger", LastName = "Woods" };
            List<PersonModel> people = new List<PersonModel>();
            // Act
            DataAccess.AddPersonToPeopleList(people, firstPerson);
            DataAccess.AddPersonToPeopleList(people, secondPerson);
            //Assert
            Assert.True(people.Count == 2);
            Assert.Contains(firstPerson, people);
            Assert.Contains(secondPerson, people);
        }

        [Theory]
        [InlineData("Bill", "", "LastName")]
        [InlineData("", "Gates", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }
    }
}
