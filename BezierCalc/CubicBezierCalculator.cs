using System;

namespace BezierCalc
{
    public class CubicBezierCalculator
    {
        public static double Value(double p0, double p1, double p2, double p3, double t)
        {
            return Math.Pow(1 - t, 3) * p0
                    + 3 * t * Math.Pow(1 - t, 2) * p1
                    + 3 * Math.Pow(t, 2) * (1 - t) * p2
                    + Math.Pow(t, 3) * p3;
        }
    }
}
