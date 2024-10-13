using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp12132.Classes;

namespace WpfApp12132.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Icalculatorintegral _rectangleCalculator;
        private Func<double, double> _func;
        private Icalculatorintegral _trapCalculator;
        [TestInitialize]
        public void Setup()
        {
            _rectangleCalculator = new CalculateRectangle();
            _func = x => 2 * x - Math.Log(2 * x) + 234;
            _trapCalculator = new Calculatetrap();
        }

        [TestMethod]
        public void RectangleCalculator_Calculate_ReturnsCorrectResult()
        {
            double lower = 1;
            double upper = 2;
            int count = 10000;
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;
            double result = _rectangleCalculator.Calculate(lower, upper, count, func);
            double expected = 235.9; 
            Assert.AreEqual(expected, result, 0.1); 
        }

        [TestMethod]
        public void TrapCalculator_Calculate_ReturnsCorrectResult()
        {
            double lower = 1;
            double upper = 2;
            int count = 10000;
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;
            double result = _trapCalculator.Calculate(lower, upper, count, func);
            double expected = 235.9; 
            Assert.AreEqual(expected, result, 0.1); 
        }

        [TestMethod]
        public void Calculator_Calculate_WithInvalidBounds_ThrowsException()
        {
            double lower = 2;
            double upper = 1;
            int count = 100;
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;

            Assert.ThrowsException<ArgumentException>(() => _rectangleCalculator.Calculate(lower,upper,count, _func));
        }

        [TestMethod]
      
        public void Calculator_Calculate_WithNegativeCount_ThrowsException()
        {
            double lower = 1;
            double upper = 2;
            int count = -1; 
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _rectangleCalculator.Calculate(lower,upper,count, _func));
        }
        [TestMethod]
        public void Calculator_Calculate_WithNullFunction_ThrowsException()
        {
            double lower = 0;
            double upper = 100;
            int count = 100000;
            Func<double, double> func = null; 
            _rectangleCalculator.Calculate(lower, upper, count, _func);
            Assert.ThrowsException<ArgumentException>(() => _rectangleCalculator.Calculate(lower,upper,count, null));
        }
        [TestMethod]
        public void Calculator_Calculate_WithInvalidBounds_ThrowsException12()
        {
            double lower = 2;
            double upper = 1;
            int count = 100;
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;

            Assert.ThrowsException<ArgumentException>(() => _trapCalculator.Calculate(lower, upper, count, _func));
        }

        [TestMethod]

        public void Calculator_Calculate_WithNegativeCount_ThrowsException12()
        {
            double lower = 1;
            double upper = 2;
            int count = -1;
            Func<double, double> func = x => 2 * x - Math.Log(2 * x) + 234;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trapCalculator.Calculate(lower, upper, count, _func));
        }
        [TestMethod]
        public void Calculator_Calculate_WithNullFunction_ThrowsException12()
        {
            double lower = 0;
            double upper = 100;
            int count = 100000;
            Func<double, double> func = null;
            _rectangleCalculator.Calculate(lower, upper, count, _func);
            Assert.ThrowsException<ArgumentException>(() => _trapCalculator.Calculate(lower, upper, count, null));
        }
    }
}
