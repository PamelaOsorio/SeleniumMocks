using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WireMock.Server; // Usar WireMock para simular a API de Login
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using ProjetoSeleniumMock.Mocks;
namespace ProjetoSeleniumMock.Hooks
{

    [Binding]
    public class TestHooks
    {
        public static WireMockServer? MockServer;
        public IWebDriver? Driver;
        private readonly ScenarioContext _context;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _context = scenarioContext;
        }

        [BeforeTestRun]
        public static void StartMock()
        {

            MockServer = WireMockServer.Start(9876);
            LoginMock.ConfigMock(MockServer);


        }

        [BeforeScenario]
        public void CreateDriver()
        {
            var options = new ChromeOptions();

            Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _context.Set(Driver);

        }

        public void TakeScreenshotIfFail()
        {
            if (_context.TestError != null)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile("erro_screenshot.png");
            }
        }

        [AfterScenario]
        public void CloseDriver()
        {
            Driver?.Quit();
            Driver?.Dispose();

        }


        [AfterScenario]


        [AfterTestRun]
        public static void StopMock()
        {
            MockServer?.Stop();
            MockServer?.Dispose();
        }
    }
}