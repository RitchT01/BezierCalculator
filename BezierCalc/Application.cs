using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace BezierCalc
{
    public class Application
    {
        private readonly  IResultsWriter _resultsWriter;
        private readonly IPointsCalculator _pointsCalculator;

        public Application(IResultsWriter resultsWriter, IPointsCalculator pointsCalculator)
        {
            _resultsWriter = resultsWriter;
            _pointsCalculator = pointsCalculator;
        }

        public void Run(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(Execute)
                    .WithNotParsed(Errors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A problem occurred while running the application: {ex.Message}");
            }
        }

        private void Errors(IEnumerable<Error> errors)
        {
            List<Error> errorList = errors.ToList();

            if (errorList.Any(e => e.Tag == ErrorType.HelpRequestedError || e.Tag == ErrorType.VersionRequestedError))
            {
                return;
            }
        }

        private void Execute(Options options)
        {
            _resultsWriter.WriteRecords(options.OutputFile, (IEnumerable) _pointsCalculator.Calculate(options));
        }
    }
}
