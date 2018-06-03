using ContadorAndreLuizMelo.Utils;
using NUnit.Framework;

namespace ContadorAndreLuizMelo.Tests
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        [OneTimeTearDown]
        public void TearDown()
        {
            HeadlessWebDriver.Quit();
        }
    }
}
