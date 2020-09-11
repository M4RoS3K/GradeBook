using System;
using System.Collections.Generic;
using System.Text;
using static GradeBook.InMemoryBook;

namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}
