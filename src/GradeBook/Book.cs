using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    // Delegate to define a event
    public delegate void GradeAddedDeligate(object sender, EventArgs args);
    /* This is a base class. 
    Used to not repeat code such as 
    the property member below 
    All classes that inherent this class
    will have the property methods, setters and getters*/
    public class namedObject
    {
        public namedObject(string name)
        {
            Name = name;
        }

        // Property member of name
        public string Name
        {
            get;
            set;
        }
        /* The compiler creates the field that
        stores the value given from the Name property 
        In the background there would now be a 
        private string name; field, */
    }
    public interface IBook
    {
        /* interface definition only describes the members 
        that should be available on a spesific type, this can be 
        added to implement the abstract class */
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDeligate GradeAdded;
    }
    public abstract class Book : namedObject, IBook
    {
        /* The abstract class is mainly used to be a base 
        class. E.g: in geometry, the abstract base class can be 
        a shape, but the child class can be a triange / square */
        public Book(string name) : base(name)
        {

        }

        public abstract event GradeAddedDeligate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        /* Abstract keywords forces the classes that implements this abstract
        class to also implement these abstract methodfs */
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name; // public member always uppercase
        }

        public override event GradeAddedDeligate GradeAdded;

        public override void AddGrade(double grade)
        {
            string fileName = $"{this.Name}.txt";
            string curr = Environment.CurrentDirectory;
            string path = Path.Combine(curr, @"src\GradeBook", fileName);

            // Create a file to write to.
            using (var writer = File.AppendText(path))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }



        }

        public override Statistics GetStatistics()
        {
            string fileName = $"{this.Name}.txt";
            string curr = Environment.CurrentDirectory;
            string path = Path.Combine(curr, @"src\GradeBook", fileName);

            var result = new Statistics();

            // Create a file to write to.
            using (var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name; // public member always uppercase
            grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            /* You can have same name on methods, however the 
            parameters cant be the same. All in all the methods signature
            are the method name and the input parameter types(plural).            
            */
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
        public override void AddGrade(double grade)
        {
            /* This has the override keyword because it
            overrides the abstract method of the base class */

            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}s");
            }
        }


        public override event GradeAddedDeligate GradeAdded; // field
        public Statistics GetStats()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);

            }
            return result;
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        // Field of grades
        private List<double> grades;



        /* constant that cant be changed, only read
         some write them with all capital letters.
         Behaves as a static member of a class, can only be 
         accessed by the typename, e.g Book, (not the object) */
        public const string CATEGORY = "Science";

    }
}