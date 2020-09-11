using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
            Name = name;
        }

        public List<double> Grades
        {
            get;
        }       
        
        public override void AddGrade(double grade)
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var i = 0; i < Grades.Count; i++)
            {
                result.Add(Grades[i]);                              
            }

            return result;
        }
    }
}
