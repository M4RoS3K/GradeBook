using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestBookAvgHighestLowestName()
        {
            // arrange
            var book = new InMemoryBook("Hanka's book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var stats = book.GetStatistics();

            // assert
            Assert.Equal("Hanka's book", book.Name);
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal(90.5, stats.Highest, 1);
            Assert.Equal(77.3, stats.Lowest, 1);
            Assert.Equal('B', stats.Letter);
        }

        [Fact]
        public void TestValidValue()
        {
            var book = new InMemoryBook("Hanka's book");

            book.AddGrade(100);

            Assert.NotEmpty(book.Grades);
        }

        [Fact]
        public void TestInValidValue()
        {
            var book = new InMemoryBook("Hanka's book");

            try
            {
                book.AddGrade(100.1);
                book.AddGrade(-0.1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.Empty(book.Grades);
        }
    }
}
