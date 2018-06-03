using ContadorAndreLuizMelo.Pages;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContadorAndreLuizMelo.Tests
{
    [TestFixture]
    public sealed class Tests : BaseTest
    {
        ContadorPage contadorPage;
        public Tests() : base()
        {
            contadorPage = new ContadorPage();
        }

        public static IEnumerable<TestCaseData> MessageExibitionTestData
        {
            get
            {
                yield return new TestCaseData("Selenium", "Did not broke the application", true);
                yield return new TestCaseData("", "", false);
            }
        }

        public static IEnumerable<TestCaseData> LastGaroteadaTextValueTestData
        {
            get
            {
                yield return new TestCaseData(10, "alguns instantes atrás");
                yield return new TestCaseData(2*60, "2 minutos atrás");
            }
        }

        [Test, TestCaseSource("MessageExibitionTestData"),Order(1)]
        public void MessageExibitionTest(string name, string description, bool success)
        {
            contadorPage.SendNewGaroteada(name, description);
            contadorPage.WaitForIt();
            Assert.IsTrue(contadorPage.MessageIsDisplayed(success));
        }

        [Test, TestCaseSource("LastGaroteadaTextValueTestData"),Order(2)]
        public void LastGaroteadaTextValueTest(int secondsToWait, string expectedText)
        {
            contadorPage.SendNewGaroteada("Let's test this", "Yay");
            contadorPage.WaitForIt(secondsToWait);
            Assert.AreEqual(expectedText, contadorPage.TimeSinceLastGaroteada);
        }
    }
}
