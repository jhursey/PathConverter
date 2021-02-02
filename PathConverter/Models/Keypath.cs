using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Serilog;
using PathConverter.Interfaces;

namespace PathConverter.Models
{
    public class Keypath : IKeypath
    {
        public List<string> Inputs { get; set; }

        public Keypath() { }

        public Keypath(List<string> inputs)
        {
            Inputs = inputs;
        }

        public override string ToString()
        {
            string message = string.Empty;

            if (Inputs.Any())
            {
                foreach (string input in Inputs)
                {
                    message += input + "\n";
                }
            }

            return message;
        }

    }
}
