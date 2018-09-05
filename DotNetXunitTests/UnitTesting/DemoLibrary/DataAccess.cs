using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DemoLibrary
{
    public static class DataAccess
    {
        private const string PersonTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = GetAllPeople();

            AddPersonToPeopleList(people, person);

            IEnumerable<string> lines = ConvertModelsToCsv(people);

            File.WriteAllLines(PersonTextFile, lines);
        }

        private static void WriteText(TextWriter file, IEnumerable<string> lines)
        {
            foreach (string lineInfo in lines)
            {
                file.WriteLine(lineInfo);
            }
        }

        public static void WriteTextToFile(IEnumerable<PersonModel> people, string path)
        {
            IEnumerable<string> lines = ConvertModelsToCsv(people);

            var file = StreamWriter.Null;
            if (File.Exists(path) == false)
            {
                // Create a file to write to.
                using (file = File.CreateText(path))
                {
                    WriteText(file, lines);
                }
            }
            else
            {
                WriteText(file, lines);
            }
        }


        public static void AppendTextToFile(PersonModel person, string path)
        {
            var csvPerson = $"{person.FirstName},{person.LastName}";

            using (var sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Equals(csvPerson))
                    {
                        return;
                    }
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(csvPerson);
            }
        }

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "LastName");
            }

            people.Add(person);
        }

        public static IEnumerable<string> ConvertModelsToCsv(IEnumerable<PersonModel> people)
        {
            return people.Select(user => $"{user.FirstName},{user.LastName}").ToList();
        }

        public static List<PersonModel> GetAllPeople()
        {
            var content = File.ReadAllLines(PersonTextFile);

            return content.Select(line => line.Split(',')).Select(personName => new PersonModel { FirstName = personName[0], LastName = personName[1] }).ToList();
        }
    }
}
