using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        private double _highest = Double.MinValue;
        private double _lowest = Double.MaxValue;
        private double _average = 0.0;
        private char _letter;

        public double Highest
        {
            get {return _highest;}
            set { _highest = value; } 
        }

        public double Lowest
        {
            get { return _lowest; }
            set { _lowest = value; }
        }

        public double Average
        {
            get { return _average; }
            set { _average = value; }
        }

        public char Letter
        {
            get { return _letter; }
            set { _letter = value; }
        }

        public void PrintStats(Statistics statistics)
        {
            Console.WriteLine($"The highest of grades is {Highest:N2}");
            Console.WriteLine($"The lowest of grades is {Lowest:N2}");
            Console.WriteLine($"The average of grades is {Average:N2}");
            Console.WriteLine($"The letter grade is {Letter}");
        }
    }
}
