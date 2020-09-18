using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Gradebook Test");
            book.AddGrade(89.1);
            book.AddGrade(99);

            var stats = book.GetStats();

            Console.WriteLine($"Average: {stats.Average}");
            Console.WriteLine($"Max: {stats.High}");
            Console.WriteLine($"Min: {stats.Low}");
            
        }
    }
}
