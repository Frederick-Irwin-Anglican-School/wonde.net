// TestWondeConsole

namespace TestWondeClient
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Wonde;
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(ConfigurationManager.AppSettings["API_TOKEN"]);
            var school = client.school(ConfigurationManager.AppSettings["SCHOOL_ID"]);

            var students = school.students.all();

            iterate(students);
            if (students.nextPage())
            {
                iterate(students);
            }

            if (students.previousPage())
            {
                iterate(students);
            }
        }

        static void iterate(ResultIterator students)
        {
            foreach (var row in students)
            {
                var obj = (Dictionary<string, object>) row;
                Console.WriteLine($"Name: {obj["forename"]} {obj["surname"]} ({obj["gender"]})");
            }
        }
    }
}