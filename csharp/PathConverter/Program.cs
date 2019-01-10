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
                System.Console.WriteLine("Please enter a filename");
                return 1;
            }

            string fileName = args[0];

            if(!File.Exists(fileName))
            {
                System.Console.WriteLine("Input file does not exist");
                return 1;
            }

            StreamReader stream = new StreamReader(fileName);
            //TODO: read file
            // line = stream.ReadLine();

            return 0;
        }
    }
}
