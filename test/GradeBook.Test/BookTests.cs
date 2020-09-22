using System;
using Xunit;

namespace GradeBook.Test
{
    
    
    public class BookTests
    {

        [Fact]
        public void ValidateErrorOfAddGrade()
        {
            var book = new InMemoryBook("");
            Assert.Throws<ArgumentException>(() => book.AddGrade(105));
        }

        [Fact]
        public void BookCalculatesAverageGrade()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(90);
            book.AddGrade(60);
            
            // Act
            var results = book.GetStats();

            // Assert
            Assert.Equal(75, results.Average);
            Assert.Equal(90, results.High);
            Assert.Equal(60, results.Low);
            Assert.Equal('C', results.Letter);
        }
    }
}
