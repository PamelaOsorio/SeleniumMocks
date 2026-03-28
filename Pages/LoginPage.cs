using OpenQA.Selenium;

namespace ProjetoSeleniumMock.Pages
{

    public class LoginPage
    {

        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) => _driver = driver;

        private IWebElement EmailField => _driver.FindElement(By.XPath("//input[@placeholder='email']"));
        private IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@placeholder='password']"));
        private IWebElement ButtonLogin => _driver.FindElement(By.XPath("//button[contains(text(), 'Login')]"));
        private IWebElement WelcomeMessage => _driver.FindElement(By.XPath("//h1[contains(@class, 'welcome')]"));


        public void EnterUser(string user)
        {
            EmailField.SendKeys(user);
            
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickOnButtonLogin() => ButtonLogin.Click();

        public string ShowMessage()
        {
            return WelcomeMessage.Text;
        }
    }
}