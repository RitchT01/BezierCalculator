using System.Collections.Generic;

namespace BezierCalc
{
    public interface IPointsCalculator
    {
        IList<Point> Calculate(Options options);
    }
}
