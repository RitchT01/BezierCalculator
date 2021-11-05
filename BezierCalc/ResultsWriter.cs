using System.Collections;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace BezierCalc
{
    public class ResultsWriter: IResultsWriter
    {
        public void WriteRecords(string outputFile, IEnumerable list)
        {
            using var writer = new StreamWriter(outputFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);
        }
    }
}
