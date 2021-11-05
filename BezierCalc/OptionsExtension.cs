using System;
using System.Linq;

namespace BezierCalc
{
    public static class OptionsExtension
    {
        public static Point CreateBezierPoint(this Options options, decimal interval)
        {
            var x = CubicBezierCalculator.Value(options.Point0.ElementAt(0), options.Point1.ElementAt(0),
                options.Point2.ElementAt(0), options.Point3.ElementAt(0), Convert.ToDouble(interval));

            var y = CubicBezierCalculator.Value(options.Point0.ElementAt(1), options.Point1.ElementAt(1),
                options.Point2.ElementAt(1), options.Point3.ElementAt(1), Convert.ToDouble(interval));

            return new Point(x, y);
        }

        public static decimal CalculateInterval(this Options options)
        {
            if (options.Intervals == 0)
            {
                return 1;
            }

            return 1m / Convert.ToDecimal(options.Intervals); 
        }
    }
}
