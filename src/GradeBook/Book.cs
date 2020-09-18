using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {

        public Book(string name)
        {
            Name = name; // public member always uppercase
            grades = new List<double>();
        }
        
        public void AddGrade(double grade) 
        {
            grades.Add(grade);
        }

        public Statistics GetStats()
        {

            var results = new Statistics();        
            results.Average = 0.0;
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                results.High = Math.Max(grade, results.High);
                results.Low = Math.Min(grade, results.Low);
                results.Average += grade;
            }

            results.Average /= grades.Count;

            return results;
        }

        private List<double> grades;
        public string Name;
    }
}