using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using static ContadorAndreLuizMelo.Utils.ApplicationConstants;

namespace ContadorAndreLuizMelo.Utils
{
    public static class HeadlessWebDriver
    {

        private static IWebDriver _driver;
        private static IWait<IWebDriver> _wait;
        private static WebDrivers _whichDriver = WebDrivers.Chrome;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
                StartDriver();
            return _driver;
        }

        private static void StartDriver()
        {
            Console.WriteLine("Abrindo navegador...");
            switch (_whichDriver)
            {
                case WebDrivers.Chrome:

                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    _driver = new ChromeDriver(options);
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    break;

                case WebDrivers.Firefox:
                case WebDrivers.Internet_Explorer:
                default:
                    //a ser implementado
                    throw new NotImplementedException("Driver not supported yet. Please choose Google Chrome.");
            }
        }

        public static IWait<IWebDriver> Wait
        {
            get
            {
                if (_wait == null)
                    StartWait();
                return _wait;
            }
        }

        private static void StartWait()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromMinutes(5),
                PollingInterval = TimeSpan.FromSeconds(2)
            };
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        }

        public static void Quit()
        {
            _driver.Quit();
            Process[] chromeDriverProcess = Process.GetProcessesByName("chromedriver.exe");
            if (chromeDriverProcess.Any())
                foreach (Process process in chromeDriverProcess)
                    process.Kill();
        }
    }
}
