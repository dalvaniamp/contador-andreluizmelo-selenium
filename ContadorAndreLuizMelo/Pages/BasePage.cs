using ContadorAndreLuizMelo.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ContadorAndreLuizMelo.Pages
{
    public abstract class BasePage
    {

        public static String URL;
        protected IWebDriver _driver;

        public BasePage()
        {
            _driver = HeadlessWebDriver.GetDriver();
            GoToPage();
            SetWebElements();
        }

        public void Refresh()
        {
            GoToPage();
        }

        public abstract void GoToPage();
        public abstract void SetWebElements(); 
        
        public void WaitForIt(int secondsToWait=1)
        {
            System.Threading.Thread.Sleep(secondsToWait*1000);
        }
    }
}
