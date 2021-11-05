using System.Collections.Generic;

namespace BezierCalc
{
    public class PointsCalculator : IPointsCalculator
    {
        public IList<Point> Calculate(Options options)
        {
            List<Point> points = new List<Point>();

            var interval = options.CalculateInterval();

            for (var t = 0m; t < 1.0m; t += interval)
            {
                points.Add(options.CreateBezierPoint(t));
            }

            points.Add(options.CreateBezierPoint(1));

            return points;
        }
    }
}
