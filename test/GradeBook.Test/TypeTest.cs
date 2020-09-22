using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string LogMessage);
    public class TypeTest
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            /* Delegates envokes multiple methods, (multi-cast delegates),
            can declear a variable and point to different methods.
            The only requirement of said methods is to match the signature of
            the delegate. For this instance, the parameter and return type is
            a string. A delegate is used when you need a variable to behave
            as a method.
            */
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage; // This line envokes another method
            log += IncrementCount; // This line envokes another method

            var result = log("Hello");
            Assert.Equal("Hello", result);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }      
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            RefBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void RefBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.NotEqual("New Name", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "Book 3");

            Assert.Equal("Book 3", book1.Name);
        }

        private void SetName(InMemoryBook book, string new_name)
        {
            book.Name = new_name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
