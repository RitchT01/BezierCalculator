using BezierCalc;
using Moq;
using NUnit.Framework;

namespace BezierCalcTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0.0d, 50, 50, 0, 0.0, ExpectedResult = 0.0d)]
        [TestCase(0.0d, 50, 50, 0, 0.4, ExpectedResult = 36.0d)]
        [TestCase(0.0d, 50, 50, 0, 0.5, ExpectedResult = 37.5d)]
        [TestCase(0.0d, 50, 50, 0, 0.7, ExpectedResult = 31.5d)]
        [TestCase(0.0d, 50, 50, 0, 1.0, ExpectedResult = 0.0d)]
        public double CalculateValueForIntervalOfT(double p0, double p1, double p2, double p3, double t)
        {
            return CubicBezierCalculator.Value(p0, p1, p2, p3, t);
        }
    }
}