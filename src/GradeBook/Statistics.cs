using System;

namespace GradeBook
{
    public class Statistics
    {
        /* This class only stores and can be used to carry around the statistics 
        of the grades. */
        public Statistics()
        {
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
        }

        public void Add(double value)
        {
            Count += 1;
            Sum += value;
            High = Math.Max(value, High);
            Low = Math.Min(value, Low);
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        double Sum;
        public int Count;

    }

}