using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            // Arrange
            var book = new Book("");
            book.AddGrade(30);
            book.AddGrade(60);
            

            // Act
            var results = book.GetStats();

            // Assert
            Assert.Equal(45, results.Average);
            Assert.Equal(60, results.High);
            Assert.Equal(30, results.Low);
        }
    }
}
