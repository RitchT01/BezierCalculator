using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace BezierCalc
{
    public class Options
    {
        [Option('0', "point0", Required = true, HelpText = "Control point 0 for the bezier, 2 comma separated values.\nx, y e.g. 10,20")]
        public IEnumerable<double> Point0 { get; set; } = new List<double>();

        [Option('1', "point1", Required = true, HelpText = "Control point 1 for the bezier, 2 comma separated values.\nx, y e.g. 80,160")]
        public IEnumerable<double> Point1 { get; set; } = new List<double>();

        [Option('2', "point2", Required = true, HelpText = "Control point 2 for the bezier, 2 comma separated values.\nx, y e.g. 180,160")]
        public IEnumerable<double> Point2 { get; set; } = new List<double>();

        [Option('3', "point3", Required = true, HelpText = "Control point3 for the bezier, 2 comma separated values.\nx, y e.g. 290,50")]
        public IEnumerable<double> Point3 { get; set; } = new List<double>();

        [Option('i', "intervals", Required = true, HelpText = "Number of intervals, used to calculate the values of t for curve e.g. 5 intervals => 6 points, increments of t=0.2, values of t [0.0, 0.2, 0.4, 0.6, 0.8, 1.0]")]
        public int Intervals { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file to write csv results e.g. ./bezier.csv")]
        public string OutputFile { get; set; }


        [Usage(ApplicationAlias = "bezier_calc")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Calculate cubic bezier curve values for the interval number specified, output to a CSV", new Options
                    {
                        Intervals = 5,
                        OutputFile = "./output.csv",
                        Point0 = new List<double>() {10.0,20.0},
                        Point1 = new List<double>() {110.0,120.0},
                        Point2 = new List<double>() {210.0,120.0},
                        Point3 = new List<double>() {340.0,20.0}
                    })
                };
            }
        }
    }
}
