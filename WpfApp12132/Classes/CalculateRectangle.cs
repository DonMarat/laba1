using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12132.Classes
{
    public class CalculateRectangle : Icalculatorintegral

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
            double sum = 0.0;
            for (int i = 0; i < count; i++)
            {
                sum += func(lower + i * h);
            }
            return h * sum;
        }
    }
}
