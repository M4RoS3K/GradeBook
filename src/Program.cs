using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Hanka's grades");
            book.GradeAdded += OnGradeAdded;

            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                string input = Console.ReadLine();

                if (input.ToLower().Equals("q"))
                {
                    break;
                }

                try
                {
                    var grade = Double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }                
            } 

            var stats = book.GetStatistics();
            Console.WriteLine($"For the {book.Name}:");
            stats.PrintStats(stats);
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
