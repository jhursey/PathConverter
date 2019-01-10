using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathConverter;

namespace PathConverterTests
{
    [TestClass]
    public class KeyPadTest
    {
        [TestMethod]
        // Tests keypad movement and wrapping
        public void KeyPadMove()
        {
            KeyPad pad = new KeyPad();

            pad.Move(Commands.UP);
            char c = pad.Select();
            Assert.AreEqual(c, '5');

            pad.Move(Commands.DOWN);
            c = pad.Select();
            Assert.AreEqual(c, 'A');

            pad.Move(Commands.LEFT);
            c = pad.Select();
            Assert.AreEqual(c, 'F');

            pad.Move(Commands.RIGHT);
            c = pad.Select();
            Assert.AreEqual(c, 'A');
        }
    }
}
