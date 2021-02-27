using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PathConverter.Domain;

namespace PathConverter
{
  public class Program
  {

    public static int Main(string[] args)
    {
      //add try-catch block for FileNotFoundException
      //do I throw the exception in the catch blow? see Chris's article in slack from the other day
      //any other exceptions I should guard against?
      
      if (args.Length != 1)
      {
        Console.WriteLine("Input a single file path to run the program.");
        return 1;
      }

      var remote = new Remote();

      var filePath = args[0];
      var keyPaths = File.ReadLines(filePath);

      var output = keyPaths
        .Select(k => remote.InterpretInput(k))
        .ToList();

      File.WriteAllLines("searchTerms.txt", output);
      return 0;
    }

    
  }
}
