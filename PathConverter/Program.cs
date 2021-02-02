using System;
using PathConverter.Models;
using PathConverter.Processors;
using Serilog;

namespace PathConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Using Serilog for logging.  Makes output simple and will write results to file.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Constants.FilePaths.LOG, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            KeypathProcessor processor = new KeypathProcessor(Log.Logger);

            string filepath = string.Empty;

            //Allowing user to enter multiple files for path conversion
            do
            {
                Console.Write("Enter file path (0 to exit): ");
                filepath = Console.ReadLine();

                if (filepath == "0")
                {
                    break;
                }

                Keypath keypath = processor.ParseFile(filepath);
                string convertedMessage = processor.ConvertKeypath(keypath, new Keyboard());

                if (!string.IsNullOrWhiteSpace(convertedMessage))
                {
                    Log.Logger.Information($"Input: {keypath} converts to {convertedMessage}");
                }

            } while (filepath != "0");

            Console.WriteLine($"Thanks for using PathConverter. Results saved in {Constants.FilePaths.LOG}. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
