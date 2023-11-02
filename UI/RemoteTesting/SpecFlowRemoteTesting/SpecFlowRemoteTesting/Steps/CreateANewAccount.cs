using SpecFlowRemoteTesting.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowRemoteTesting.Steps;

[Binding]
public class CreateANewAccount 
{
    private readonly LoginPageObject _loginPageObject;
    
    public CreateANewAccount(ChromeBrowserDriver chromeBrowserDriver) => 
        _loginPageObject = new LoginPageObject(chromeBrowserDriver.Current);
    
    [Given(@"Jacob, a real bookworm, wants to register an account with Bruna")]
    public void GivenJacobARealBookwormWantsToRegisterAnAccountWithBruna()
    {
    }
    
    [When(@"goes to the login page")]
    public void WhenGoesToTheLoginPage()
    {
        _loginPageObject.EnsurePageIsOpenAndReady();
    }
    
    [When(@"enters the email address '(.*)'")]
    public void WhenEntersTheEmailAddress(string emailAddress)
    {
        _loginPageObject.EnterEmailAddress(emailAddress);
        _loginPageObject.SubmitEmailAddress();
    }

    [Then(@"he can enter the details of his new account")]
    public void ThenHeCanEnterTheDetailsOfHisNewAccount()
    {
        _loginPageObject.TakeScreenshot("ThenHeCanEnterTheDetailsOfHisNewAccount.png");
        Assert.True(_loginPageObject.NewAccountPageIsLoaded());
    }

    [Then(@"he receives an error")]
    public void ThenHeReceivesAnError()
    {
        _loginPageObject.TakeScreenshot("ThenHeReceivesAnError.png");
        Assert.True(_loginPageObject.AccountErrorIsShown());
    }
} 