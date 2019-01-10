using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathConverter;

namespace PathConverterTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        // Tests key path decoding
        public void ControllerDecode()
        {
            string testString = "DDDR*UU*LLLU*SDD*DLL*UU*U*RRD*SURRR*LLDD*LLL*DRR*RRRU*SUULL*DDLLL*LLLD*SUULL*DDL*LLU*RRR*UUR*L*SDDL*RD*UUUR*DDR*SRRD*UU*LLLU*SDR*RU*UUR*L*SDDRRR*DDL*LLU*";
            string expectedOutput = "THE QUICK BROWN FOX JUMPED OVER THE LAZY DOG";
            Controller controller = new PathConverter.Controller();
            string searchTerm = controller.DecodePath(testString);
            Assert.AreEqual(searchTerm, expectedOutput);
        }
    }
}
