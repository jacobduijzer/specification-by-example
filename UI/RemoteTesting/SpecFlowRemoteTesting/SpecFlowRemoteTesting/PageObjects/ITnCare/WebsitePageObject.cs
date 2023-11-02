using OpenQA.Selenium;

namespace SpecFlowRemoteTesting.PageObjects.ITnCare;

public class WebsitePageObject : PageObjectBase
{
    private const string BookshopHomeUrl = "https://www.itandcare.nl";

    public WebsitePageObject(IWebDriver webDriver) : base(webDriver)
    {
        
    }

    public void OpenWebsite()
    {
        if (WebDriver.Url == BookshopHomeUrl) return;

        WebDriver.Url = BookshopHomeUrl;

        var element = FindElement(By.Id("menu-item-50377"));
    }

    public void ClickOnLinkToJobs()
    {
        var element = FindElement(By.XPath("//a[@title='Vacatures']"));
        element.Click();
    }

    public bool UserIsRedirected()
    {
        return WebDriver.Url.Equals("https://www.werkenbijhumantotalcare.nl/it-and-care");
    }

   

}