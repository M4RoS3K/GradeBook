﻿using System;
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

        public List<double> Grades
        {
            get { return grades; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }      

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid grade {grade}");
            }
        }

        public void AddLetterGrade(char letter)
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

            for (var i = 0; i < grades.Count; i++)
            {
                result.Highest = Math.Max(grades[i], result.Highest);
                result.Lowest = Math.Min(grades[i], result.Lowest);
                result.Average += grades[i];
            }

            result.Average /= grades.Count;

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
