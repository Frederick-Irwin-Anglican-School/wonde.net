// TestWondeConsole

namespace TestWondeClient;

#region Using Directives
using System;
using System.Configuration;
using System.Text.Json;
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
            // TODO: Convert to a strongly typed object instead of using JsonElement
            var element = (JsonElement) row;

            var forename = element.GetProperty("forename").GetString();
            var surname  = element.GetProperty("surname").GetString();
            var gender   = element.GetProperty("gender").GetString();

            Console.WriteLine($"Name: {forename} {surname} ({gender})");
        }
    }
}