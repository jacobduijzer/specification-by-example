using OpenQA.Selenium;

namespace SpecFlowRemoteTesting.PageObjects;

public class LoginPageObject : PageObjectBase
{
    private const string BookshopHomeUrl = "https://www.bruna.nl/inloggen";

    private IWebElement CookieButton => WebDriver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
    private IWebElement EmailTextBox => WebDriver.FindElement(By.Id("emailRegistration"));
    private IWebElement SubmitButton => WebDriver.FindElement(By.ClassName("bg-buttonPrimaryBackground"));

    public LoginPageObject(IWebDriver webDriver) : base(webDriver)
    {
        
    }
    
    public void EnsurePageIsOpenAndReady()
    {
        if (WebDriver.Url == BookshopHomeUrl) return;
        
        WebDriver.Url = BookshopHomeUrl;
        try
        {
            CookieButton.Click();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public void EnterEmailAddress(string emailAddress)
    {
        EmailTextBox.SendKeys(emailAddress);
    }

    public void SubmitEmailAddress()
    {
        SubmitButton.Click();
    }

    public bool NewAccountPageIsLoaded()
    {
        var element = FindElement(By.Id("firstName"));
        return true;
    }

    public bool AccountErrorIsShown()
    {
        var element = WaitUntil(
            () => WebDriver.FindElement(By.ClassName("form-control-error-message")),
            result => result.Displayed);

        return element.Text.Equals("Hé, er klopt iets niet aan je e-mailadres. Check je of het compleet is?");
    }
}