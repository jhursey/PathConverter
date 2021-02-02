using System;
using System.Collections.Generic;
using System.Text;


namespace PathConverter.Interfaces
{
    /// <summary>
    /// Keypath interface allows for many different inputs
    /// </summary>
    public interface IKeypath
    {
        public List<string> Inputs { get; set; }
    }
}
