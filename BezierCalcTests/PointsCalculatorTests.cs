using BezierCalc;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace BezierCalcTests
{
    [TestFixture]
    public class PointsCalculatorTests 
    {
        private IPointsCalculator _pointsCalculator;

        [SetUp]
        public void Setup()
        {
            _pointsCalculator = new PointsCalculator();
        }

        [Test]
        public void PointsCalculator_Returns_Correct_Bezier_Points_List()
        {
            // Arrange
            Options options = CreateOptions();
            var expected = CreateBezierPointsList();

            // Act
            var actual = _pointsCalculator.Calculate(options);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void PointsCalculator_Interval_Set_To_Zero_Returns_Correct_Bezier_Points_List()
        {
            // Arrange
            Options options = CreateOptions();
            options.Intervals = 0;
            var expected = CreateBezierPointsListZeroInterval();

            // Act
            var actual = _pointsCalculator.Calculate(options);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void PointsCalculator_Returns_Correct_Number_Of_Bezier_Points()
        {
            // Arrange
            Options options = CreateOptions();
            options.Intervals = 10;
            var expected = 11;

            // Act
            var bezierPointsList = _pointsCalculator.Calculate(options);
            var actual = bezierPointsList.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private Options CreateOptions()
        {
            return new Options
            {
                Point0 = CreateOptionsPoint(10,90),
                Point1 = CreateOptionsPoint(60,100),
                Point2 = CreateOptionsPoint(130,420),
                Point3 = CreateOptionsPoint(240,0),
                Intervals = 5
            };
        }

        private List<double> CreateOptionsPoint(double x, double y)
        {
            return new List<double>
            {
                x,y
            };
        }

        private IList<Point> CreateBezierPointsList()
        {
            return new List<Point>
            {
                new Point(10, 90),
                new Point(42.560000000000016, 124.80000000000004),
                new Point(80.88000000000001, 183.60000000000002),
                new Point(125.92, 216.00000000000003),
                new Point(178.64000000000001, 171.6),
                new Point(240, 0)
            };
        }

        private IList<Point> CreateBezierPointsListZeroInterval()
        {
            return new List<Point>
            {
                new Point(10, 90),
                new Point(240, 0)
            };
        }
    }
}
