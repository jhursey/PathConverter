using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathConverter
{
    // Sends commands to keypad and accumulates selections
    class Controller
    {
        public string DecodePath(string keyPath)
        {
            KeyPad keyPad = new KeyPad();
            StringBuilder searchTerm = new StringBuilder();
            foreach(char ch in keyPath)
            {
                switch(ch)
                {
                    case char c when c == Commands.UP ||
                            c == Commands.DOWN ||
                            c == Commands.LEFT ||
                            c == Commands.RIGHT:
                        keyPad.Move(c);
                        break;
                    case char c when c == Commands.SPACE:
                        searchTerm.Append(' ');
                        break;
                    case char c when c == Commands.SELECT:
                        searchTerm.Append(keyPad.Select());
                        break;
                    default:
                        // An unexpected character was encountered, so exit application
                        Console.WriteLine($"Malformed input in Controller.DecodePath: {ch}");
                        Environment.Exit(-1);
                        break;
                }
            }
            return searchTerm.ToString();
        }
    }
}
