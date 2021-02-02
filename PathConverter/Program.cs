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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Files\\file.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            KeypathProcessor processor = new KeypathProcessor(Log.Logger);

            string filepath = string.Empty;

            do
            {
                Console.Write("Enter file path: (0 to exit): ");
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

                Console.WriteLine("Thanks for using PathConverter. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
