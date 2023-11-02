using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowRemoteTesting;

public class ChromeBrowserDriver : IDisposable
{
    private readonly Lazy<IWebDriver> _currentWebDriverLazy;
    private bool _isDisposed;

    public ChromeBrowserDriver()
    {
        _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
    }

    public IWebDriver Current => _currentWebDriverLazy.Value;

    private IWebDriver CreateWebDriver()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .Build();

        var testSettings = configuration.GetRequiredSection("TestSettings").Get<TestSettings>()!;
        var chromeDriverService = ChromeDriverService.CreateDefaultService();

        var chromeOptions = new ChromeOptions();
        if(testSettings.HeadLess)
            chromeOptions.AddArguments("--headless=new", "--whitelisted-ips", "--no-sandbox", "--incognito");
        else
            chromeOptions.AddArguments("--whitelisted-ips", "--no-sandbox", "--incognito");
        
        var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
        chromeDriver.Manage().Cookies.DeleteAllCookies();
        return chromeDriver;
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        if (_currentWebDriverLazy.IsValueCreated)
        {
            Current.Quit();
        }

        _isDisposed = true;
    }
}