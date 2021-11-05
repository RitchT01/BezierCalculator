using System.Collections;

namespace BezierCalc
{
    public interface IResultsWriter
    {
        void WriteRecords(string outputFile, IEnumerable list);
    }
}
