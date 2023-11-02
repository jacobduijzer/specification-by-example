using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowRemoteTesting.PageObjects;

public class BookShopPageObject : PageObjectBase
{
    private const string BookshopHomeUrl = "https://www.bruna.nl";

    private IWebElement SearchBar => WebDriver.FindElement(By.ClassName("form-search_query"));
    private IWebElement SearchButton => WebDriver.FindElement(By.ClassName("search-icon"));
    private IWebElement ResultText => WebDriver.FindElement(By.ClassName("results-section"));

    public BookShopPageObject(IWebDriver webDriver) : base(webDriver)
    {
        
    }

    public void EnsurePageIsOpenAndReady()
    {
        if (WebDriver.Url == BookshopHomeUrl) return;
        
        WebDriver.Url = BookshopHomeUrl;
        
        try
        {
            var cookieElement = FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
            cookieElement.Click();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void EnterSearchText(string searchText)
    {
        SearchBar.SendKeys(searchText);
    }

    public void SubmitSearchText()
    {
        SearchButton.Click();
    }
    
    public string WaitForNonEmptyResult()
    {
        return WaitUntil(
            () => ResultText.GetAttribute("outerText"),
            result => !string.IsNullOrEmpty(result));
    }
}