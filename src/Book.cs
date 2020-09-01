using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string _name;        

        public Book(string name)
        {
            grades = new List<double>();
            _name = name;
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }      

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            
            foreach (var number in grades)
            {
                if (number > result.Highest)
                {
                    result.Highest = number;
                }

                if(number < result.Lowest)
                {
                    result.Lowest = number;
                }

                result.Average += number;
            }

            result.Average /= grades.Count;

            return result;
        }
    }
}
