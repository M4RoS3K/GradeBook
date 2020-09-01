using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void TestStringsBehaveLikeValueTypes()
        {
            string name = "Hanka";
            var upper = MakeUpperCase(name);

            Assert.Equal("Hanka", name);
            Assert.Equal("HANKA", upper);
        }

        private string MakeUpperCase(string param)
        {
            return param.ToUpper();
        }

        [Fact]
        public void TestValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        [Fact]
        public void TestCSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void TestCSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void TestCanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            Assert.Equal("New Name", book2.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void TestBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TestTwoVarsCanReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
