using OverwatchRestReader_Terminal.Menus;
namespace ORR_Terminal_UnitTests
{
    [TestClass]
    public abstract class CommandObjectModelTest
    {
        protected abstract CommandObjectModel CreateInstance();

        [TestMethod]
        public void InstantiationTest()
        {
            CommandObjectModel instance = CreateInstance();
        }
    }
}