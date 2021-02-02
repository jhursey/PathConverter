using System;
using System.Collections.Generic;
using System.Text;
using PathConverter.Interfaces;

namespace PathConverter.Models
{
    /// <summary>
    /// Represents a keyboard in a 2 dimensional List of keys.
    /// </summary>
    public class Keyboard : IKeyboard
    {       
        public Keyboard()
        {
            Keys = new List<List<char>>
            {
                new List<char>{'A','B','C','D','E','F'},
                new List<char>{'G','H','I','J','K','L'},
                new List<char>{'M','N','O','P','Q','R'},
                new List<char>{'S','T','U','V','W','X'},
                new List<char>{'Y','Z','1','2','3','4'},
                new List<char>{'5','6','7','8','9','0'}
            };
        }

        public List<List<char>> Keys { get; }
    }
}
