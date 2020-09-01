using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Book book = new Book("Hanka's grades");

            book.AddGrade(89.1231368);
            book.AddGrade(90.56548);
            book.AddGrade(11.15648);

            var stats = book.GetStatistics();
            stats.PrintStats(stats);

            sw.Stop();
            Console.WriteLine($"Program took {sw.ElapsedMilliseconds} ms");
        }
    }
}
