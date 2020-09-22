using System;

namespace GradeBook
{
    
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Gradebook Test");
            book.GradeAdded += OnGradeAdded; // Event

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Name of book: {book.Name}");
            Console.WriteLine($"Average: {stats.Average}");
            Console.WriteLine($"Max: {stats.High}");
            Console.WriteLine($"Min: {stats.Low}");
            Console.WriteLine($"The letter is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.Write("Write grade: ");
                var grade = Console.ReadLine();

                if (grade.ToLower() == "q")
                {
                    break;
                }
                try
                {
                    book.AddGrade(double.Parse(grade));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added!");
        }
    }
}
