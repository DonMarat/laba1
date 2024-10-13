using System;
using System.Linq;

namespace WpfApp12132.Classes
{
    public class Calculatetrap: Icalculatorintegral
    {
        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (lower > upper)
                throw new ArgumentException("Lower are greater than Upper");

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count) + "is not positive");

            if (func == null)
                throw new ArgumentException("Function is null");
            double h = (upper - lower) / count;
            double sum = Enumerable.Range(0, count).Sum(s => func(s * h + lower));

            return h * ((func(upper) + func(lower)) / 2 + sum);
        }
    }
}