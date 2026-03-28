using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoSeleniumMock.Pages;
using TechTalk.SpecFlow;
using ProjetoSeleniumMock.Hooks;
using WireMock.Server;
using FluentAssertions;

namespace ProjetoSeleniumMock.StepDefinitions
{
    [TestFixture]
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly IWebDriver _driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>(); //driver injetado com hook
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"que eu acesso a página de login")]
        public void UrlPage()
        {

            _driver.Navigate().GoToUrl("http://host.docker.internal:9876/login");
        }

        [When(@"preencher o campo de usuário com ""(.*)""" )]
        public void TypeFieldEmail(string user)
        {
            _loginPage.EnterUser(user);

        }

        [When(@"preencher o campo de senha com ""(.*)""" )]
            public void TypeFieldPassword(string password)
        {
            _loginPage.EnterPassword(password);

        }

         [When(@"clicar no botão de entrar")]
            public void LogIn()
        {

            _loginPage.ClickOnButtonLogin();

            _driver.Navigate().GoToUrl("http://host.docker.internal:9876/home");
        }
        [Then(@"o usuário deverá visualizar na tela a mensagem ""(.*)""")]
        public void ValidMessage(string message)
        {
            string RightMessage = _loginPage.ShowMessage();
            Assert.That(RightMessage, Does.Contain(message));
        }

        [Then(@"o log do servidor deverá retornar com uma resposta HTTP 200")]
        public void ResponseHTTP()
        {
        var log = TestHooks.MockServer.LogEntries;
        log.Any(x => x.ResponseMessage.StatusCode != null && (int)x.ResponseMessage.StatusCode == 200)
       .Should().BeTrue("O WireMock deveria ter registrado um status 200");
        }

    }
}