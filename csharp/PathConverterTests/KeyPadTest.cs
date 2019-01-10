using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathConverter;

namespace PathConverterTests
{
    [TestClass]
    public class KeyPadTest
    {
        [TestMethod]
        public void KeyPadMove()
        {
            KeyPad pad = new KeyPad();
            pad.Move(Commands.UP);
            char c = pad.Select();
            Assert.AreEqual(c, '5');
        }
    }
}
