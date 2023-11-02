using SpecFlowRemoteTesting.PageObjects.ITnCare;
using TechTalk.SpecFlow;

namespace SpecFlowRemoteTesting.Steps;

[Binding]
public class BrowseTheItAndCareWebsite 
{
    private readonly WebsitePageObject _websitePageObject;

    public BrowseTheItAndCareWebsite(ChromeBrowserDriver chromeBrowserDriver) =>
        _websitePageObject = new WebsitePageObject(chromeBrowserDriver.Current);
    
    [Given(@"Hans, a C\# developer, is looking for a new job")]
    public void GivenHansACSharpDeveloperIsLookingForANewJob()
    {
       // DO NOTHING 
    }

    [When(@"he opens the website of IT&Care")]
    public void WhenHeOpensTheWebsiteOfItCare()
    {
        _websitePageObject.OpenWebsite();
        _websitePageObject.TakeScreenshot("WhenHeOpensTheWebsiteOfItCare.png");
    }

    [When(@"he goes to the '(.*)' page")]
    public void WhenHeGoesToThePage(string vacatures)
    {
        _websitePageObject.ClickOnLinkToJobs();
    }

    [Then(@"he will be redirected to the IT&Care page on the '(.*)' website")]
    public void ThenHeWillBeRedirectedToTheItCarePageOnTheWebsite(string p0)
    {
        Assert.True(_websitePageObject.UserIsRedirected());
    }
}