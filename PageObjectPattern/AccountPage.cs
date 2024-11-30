using OpenQA.Selenium;

public class AccountPage
{
    private readonly IWebDriver _driver;
    private readonly By _depositTab = By.CssSelector("button[ng-click='deposit()']");
    private readonly By _depositInput = By.CssSelector("input[ng-model='amount']");
    private readonly By _depositButton = By.CssSelector("button[type='submit']");

    public AccountPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void GoToDepositTab()
    {
        _driver.FindElement(_depositTab).Click();
    }

    public void DepositAmount(string amount)
    {
        _driver.FindElement(_depositInput).SendKeys(amount);
        _driver.FindElement(_depositButton).Click();
    }
}
