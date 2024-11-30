using OpenQA.Selenium;

public class CustomerLoginPage
{
    private readonly IWebDriver _driver;
    private readonly By _customerDropdown = By.Id("userSelect");
    private readonly By _loginButton = By.CssSelector("button[type='submit']");

    public CustomerLoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void SelectCustomer(string customerName)
    {
        var dropdown = _driver.FindElement(_customerDropdown);
        var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(dropdown);
        selectElement.SelectByText(customerName);
    }

    public void ClickLogin()
    {
        _driver.FindElement(_loginButton).Click();
    }
}
