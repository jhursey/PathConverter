using System;
using System.IO;
using System.Linq;
using PathConverter.Domain;

namespace PathConverter
{
  public class Driver
  {
    public static int Main(string[] args)
    {
      try
      {
        if (args.Length != 1)
        {
          Console.WriteLine("Input a single file path to run the program.");
          return 1;
        }

        var remote = new Remote();

        var filePath = args[0];
        var keyPaths = File.ReadLines(filePath);

        var output = keyPaths
          .Select(k =>
            remote.InterpretInput(k.ToUpper().Trim()));

        File.WriteAllLines("searchTerms.txt", output);
        return 0;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine("Double-check that you input your filepath correctly.");
        return 1;
      }
    }
  }
}
