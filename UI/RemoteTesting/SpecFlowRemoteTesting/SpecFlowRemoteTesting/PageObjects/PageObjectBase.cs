using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowRemoteTesting.PageObjects;

public class PageObjectBase
{
    protected readonly IWebDriver WebDriver;
    private const int DefaultWaitInSeconds = 5;
    private const string ScreenshotFilePath = ".";

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

    protected IWebElement FindElement(By by)
    {
        var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(drv => drv.FindElement(by));
    }
    
    public string TakeScreenshot(string screenshotFileName)
    {
        return "";
        // var screenshotImage = GetScreenshot();
        //
        // // string workingDirectory = Environment.CurrentDirectory;
        // // string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // // var fullScreenShotFilePath = Path.Combine(projectDirectory, "screenshots", screenshotFileName);
        // if (!Path.Exists("/app"))
        //     throw new Exception("Path '/app' not found.");
        //
        // var fullScreenShotFilePath = Path.Combine("/app", "output", screenshotFileName);
        // Console.WriteLine($"Full screenshot file path: '{fullScreenShotFilePath}'");
        //
        // var successfullySaved = TryToSaveScreenshot(fullScreenShotFilePath,  screenshotImage);
        //
        // return successfullySaved ? ScreenshotFilePath : "";
    }
    private Screenshot? GetScreenshot()
    {
        return ((ITakesScreenshot) WebDriver)?.GetScreenshot();
    }
    private bool TryToSaveScreenshot(string screenshotFileName, Screenshot? screenshotImage)
    {
        try
        {
            SaveScreenshotAsFile(screenshotFileName, screenshotImage);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    private void SaveScreenshotAsFile(string screenshotFilePath, Screenshot? screenshotImage)
    {
        if (screenshotImage == null)
            return;
        screenshotImage.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
    } 
}