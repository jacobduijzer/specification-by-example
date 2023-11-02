using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowRemoteTesting.PageObjects;

public class PageObjectBase
{
    protected readonly IWebDriver WebDriver;
    private const int DefaultWaitInSeconds = 5;

    protected PageObjectBase(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    protected T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
    {
        var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(driver =>
        {
            var result = getResult();
            if (!isResultAccepted(result))
                return default;

            return result;
        });
    }

    public IWebElement FindElement(By by)
    {
        var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(drv => drv.FindElement(by));
    }
}