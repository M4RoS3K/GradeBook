using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;

        public Book(string name)
        {
            Grades = new List<double>();
            Name = name;
        }

        public List<double> Grades
        {
            get;
        }
        public string Name
        {
            get; 
            set;
        }        
        
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid grade {grade}");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var i = 0; i < Grades.Count; i++)
            {
                result.Highest = Math.Max(Grades[i], result.Highest);
                result.Lowest = Math.Min(Grades[i], result.Lowest);
                result.Average += Grades[i];
            }

            result.Average /= Grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}
