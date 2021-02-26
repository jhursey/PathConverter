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
      if (args.Length != 1)
      {
        Console.WriteLine("Input a single file path to run the program.");
        return 1;
      }

      var remote = new Remote();

      var filePath = args[0];
      //prolly need to do more sanitizing here 
      var lines = File.ReadLines(filePath);

      var output = lines
        .Select(line => InterpretInput(remote, line))
        .ToList();

      File.WriteAllLines("searchTerms.txt", output);
      return 0;
    }

    //this can be moved into Remote class, and the characters themselves can be extracted into
    //a class so that we aren't married to this encoding
    private static string InterpretInput(Remote remote, string keyPath)
    {
      foreach (var c in keyPath)
      {
        switch (c)
        {
          case '*':
            remote.AddCharacterToSearch();
            break;
          case 'S':
            remote.AddSpaceToSearch();
            break;
          case 'U':
            remote.MovePointerUp();
            break;
          case 'D':
            remote.MovePointerDown();
            break;
          case 'L':
            remote.MovePointerLeft();
            break;
          case 'R':
            remote.MovePointerRight();
            break;
        }
      }

      return remote.GetCurrentSearchTerm();
    }
  }
}
