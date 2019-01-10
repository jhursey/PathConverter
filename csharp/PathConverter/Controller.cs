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
                        // For now we will do nothing in the case of an unexpected command,
                        // since there are no explicit requirements for this case
                        break;
                }
            }
            return searchTerm.ToString();
        }
    }
}
