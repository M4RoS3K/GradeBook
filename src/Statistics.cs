using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        private double _highest;
        private double _lowest;        
        private double _sum;
        private int _count;

        public Statistics()
        {
            _highest = Double.MinValue;
            _lowest = Double.MaxValue;            
            _sum = 0.0;
        }

        public void Add(double number)
        {
            _sum += number;
            _count++;
            _highest = Math.Max(number, _highest);
            _lowest = Math.Min(number, _lowest);
        }

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
            get { return _sum / _count; }            
        }

        public char Letter
        {
            get {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';                        

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
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