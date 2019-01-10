using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PathConverter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a filename");
                return 1;
            }

            string fileName = args[0];

            if(!File.Exists(fileName))
            {
                Console.WriteLine("Input file does not exist");
                return 1;
            }

            Controller controller = new Controller();
            List<string> searchTerms = new List<string>();
            try
            {
                using (StreamReader stream = new StreamReader(fileName))
                {
                    string keyPath = stream.ReadLine();
                    string searchTerm = controller.DecodePath(keyPath);
                    searchTerms.Add(searchTerm);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            string outputFileName = "PathConverterOutput.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach(string searchTerm in searchTerms)
                    {
                        writer.Write(searchTerm);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write to file {outputFileName}");
                Console.WriteLine(e.Message);
            }

            return 0;
        }
    }
}
