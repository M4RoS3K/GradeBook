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
            stats.PrintStats(stats);
        }
    }
}
