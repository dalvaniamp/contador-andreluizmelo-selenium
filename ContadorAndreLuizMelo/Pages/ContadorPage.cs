using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ContadorAndreLuizMelo.Pages
{
    public sealed class ContadorPage:BasePage
    {
        [FindsBy(How = How.Id, Using = "input_meliante")]
        private IWebElement _inputMeliante;

        [FindsBy(How = How.Id, Using = "input_descricao")]
        private IWebElement _inputDescricao;

        [FindsBy(How = How.Id, Using = "sendWrongDoingButton")]
        private IWebElement _buttonGarotearam;

        [FindsBy(How = How.XPath, Using = "//div[@id='form-messages']//span[contains(@class,'message successmessage')]")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='form-messages']//span[contains(@class,'message errormessage')]")]
        private IWebElement _errorMessage;

        [FindsBy(How = How.XPath, Using = "//*[@id='timepassed']")]
        private IWebElement _textTimePassed;

        public override void GoToPage()
        {
            string url= System.Configuration.ConfigurationManager.AppSettings["Contador_URL"];
            _driver.Navigate().GoToUrl(url);
        }

        public override void SetWebElements()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void SendNewGaroteada(string nomeDoMeliante, string descricaoDaGaroteada)
        {
            _inputMeliante.Clear();
            _inputMeliante.SendKeys(nomeDoMeliante);
            _inputDescricao.Clear();
            _inputDescricao.SendKeys(descricaoDaGaroteada);
            _buttonGarotearam.Click();
        }

        public bool MessageIsDisplayed(bool success)
        {
            if (success)
                return _successMessage.Displayed;
            return _errorMessage.Displayed;
        }

        public string TimeSinceLastGaroteada => _textTimePassed.Text;
    }
}
