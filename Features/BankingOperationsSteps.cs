using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

[Binding]
public class BankingOperationsSteps
{
    private IWebDriver driver;
    [BeforeScenario]
    public void Setup()
    {
        driver = new ChromeDriver();
    }


    [Given(@"the customer navigates to the GlobalSQA Banking Project page")]
    public void GivenTheCustomerNavigatesToTheGlobalSQABankingProjectPage()
    {
      
        driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
        
    }

    

    [When(@"the customer logs in")]
    public void WhenTheCustomerLogsIn()
    {
        Thread.Sleep(3000);
        driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[1]/div[1]/button")).Click();
    }

    [When(@"the customer selects ""(.*)"" as their login name")]
    public void GivenTheCustomerSelectsAsTheirLoginName(string customerName)
    {
        Thread.Sleep(3000);
        var customerDropdown = new SelectElement(driver.FindElement(By.Id("userSelect")));
        customerDropdown.SelectByText(customerName);
        driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/button")).Click();
    }

    [When(@"the customer selects the ""(.*)"" tab")]
    public void WhenTheCustomerSelectsTheTab(string tabName)
    {
        Thread.Sleep(2000);
        driver.FindElement(By.XPath($"//button[contains(text(), '{tabName}')]")).Click();
    }

    [When(@"the customer enters an amount of ""(.*)"" to deposit")]
    public void WhenTheCustomerEntersAnAmountOfToDeposit(string amount)
    {
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[4]/div/form/div/input")).SendKeys(amount);
        driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[4]/div/form/button")).Click();
    }

    [Then(@"the system should display a successful deposit message")]
    public void ThenTheSystemShouldDisplayASuccessfulDepositMessage()
    {
        Thread.Sleep(2000);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var successMessageElement = wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[4]/div/span")));
        string successMessage = successMessageElement.Text;
        Assert.That(successMessage.Contains("Deposit Successful"), Is.True, "Message did not contain 'Deposit Successful'");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
