using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowRemoteTesting.PageObjects;

public class BookShopPageObject
{
    private const string bookshopHomeUrl = "https://www.bruna.nl";

    private readonly IWebDriver _webDriver;

    public const int DefaultWaitInSeconds = 5;

    private IWebElement _cookieButton => _webDriver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
    private IWebElement _searchBar => _webDriver.FindElement(By.ClassName("form-search_query"));
    private IWebElement _searchButton => _webDriver.FindElement(By.ClassName("search-icon"));
    private IWebElement _resultText => _webDriver.FindElement(By.ClassName("results-section"));

    public BookShopPageObject(IWebDriver webDriver) => _webDriver = webDriver;
    
    public void EnsureCalculatorIsOpenAndReset()
    {
        if (_webDriver.Url != bookshopHomeUrl)
        {
            _webDriver.Url = bookshopHomeUrl;
            // if(_cookieButton != null)
            try
            {
                _cookieButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //Otherwise reset the calculator by clicking the reset button
        else
        {
            // //Click the rest button
            // ResetButtonElement.Click();
            //
            // //Wait until the result is empty again
            // WaitForEmptyResult();
        }
    }

    public void EnterSearchText(string searchText)
    {
        _searchBar.SendKeys(searchText);
    }

    public void SubmitSearchText()
    {
        _searchButton.Click();
    }
    
    public string WaitForNonEmptyResult()
    {
        return WaitUntil(
            () => _resultText.GetAttribute("outerText"),
            result => !string.IsNullOrEmpty(result));
    }
    
    private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T: class
    {
        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(driver =>
        {
            var result = getResult();
            if (!isResultAccepted(result))
                return default;

            return result;
        });
    }
}