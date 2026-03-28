using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoSeleniumMock.Pages;
using TechTalk.SpecFlow;

namespace ProjetoSeleniumMock.StepDefinitions
{
    [TestFixture]
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly IWebDriver _driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>(); //driver injetado com hook
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"que eu acesso a página de login")]
        public void UrlPage()
        {

            _driver.Navigate().GoToUrl("http://host.docker.internal:9876/login");
        }

        [When(@"eu faço login com ""(.*)"" e ""(.*)""")]
        public void LogIn(string user, string password)
        {
            _loginPage.EnterYourCredentials(user, password);
            _loginPage.ClickOnButtonLogin();

            _driver.Navigate().GoToUrl("http://host.docker.internal:9876/home");
        }

        [Then(@"o sistema deverá retornar na tela a mensagem ""(.*)""")]
        public void ValidMessage(string message)
        {
            string RightMessage = _loginPage.ShowMessage();
            Assert.That(RightMessage, Does.Contain(message));
        }
    }
}