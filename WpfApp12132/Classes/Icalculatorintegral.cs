using System;

namespace WpfApp12132.Classes
{
    public interface Icalculatorintegral
    {
            double Calculate(double lower, double upper, int count, Func<double, double> func);
    }
}
