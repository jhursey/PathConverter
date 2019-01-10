using System;
using System.Collections.Generic;
using System.IO;

namespace PathConverter
{
    /* Main program runner. Takes input file and passes contents to a Controller
     * line by line
     */
    class Program
    {
        static int Main(string[] args)
        {
            // If no arguments passed in, write an error
            if (args.Length == 0)
            { 
                Console.WriteLine("Please enter a filename");
                return 1;
            }

            string fileName = args[0];

            // Pick a somewhat unique default output file name
            string outputFileName = "PCOut" + DateTimeOffset.Now.ToUnixTimeMilliseconds() + ".txt";

            // If more than one argument passed in, use 2nd as output file
            if (args.Length > 1)
            { 
                outputFileName = args[1];
            }

            // Make sure input file exists
            if (!File.Exists(fileName))
            { 
                Console.WriteLine("The input file does not exist");
                return 1;
            }

            // Create a Controller which takes inputs and simulates movement around keypad
            Controller controller = new Controller();
            List<string> searchTerms = new List<string>();
            try
            {
                using (StreamReader stream = new StreamReader(fileName))
                {
                    string keyPath;
                    // Each line is a keypath, so process them one at a time
                    while ((keyPath = stream.ReadLine()) != null)
                    {
                        string searchTerm = controller.DecodePath(keyPath);
                        searchTerms.Add(searchTerm);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The input file could not be read:");
                Console.WriteLine(e.Message);
                return 1;
            }
            
            // Write decoded search terms to output file
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    // Write search terms to output file
                    foreach(string searchTerm in searchTerms)
                    {
                        writer.WriteLine(searchTerm);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write to output file {outputFileName}");
                Console.WriteLine(e.Message);
                return 1;
            }

            return 0;
        }
    }
}
