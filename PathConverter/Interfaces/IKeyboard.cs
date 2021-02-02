using System;
using System.Collections.Generic;
using System.Text;

namespace PathConverter.Interfaces
{
    /// <summary>
    /// Keyboard Interface allows for many different configurations of keyboards to be used
    /// </summary>
    public interface IKeyboard
    {
        public List<List<char>> Keys { get; }
    }
}
