using System;
using System.IO;

namespace PathConverter
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args.Length < 2) {
				Console.Error.WriteLine("Invalid Usage");
				Console.Error.WriteLine("Usage: pathconverter {inputPath} {outputPath}");
				return;
			}
			String path = args[0];
			string[] lines = File.ReadAllLines(path);

			string[] evaluatedLines = new string[lines.Length];
			KeypadEvaluator evaluator = new KeypadEvaluator();
			for (int i = 0; i < lines.Length; i++) {
				evaluatedLines[i] = evaluator.Evaluate(lines[i]);
			}

			File.WriteAllLines(args[1], evaluatedLines);
        }
    }
}
