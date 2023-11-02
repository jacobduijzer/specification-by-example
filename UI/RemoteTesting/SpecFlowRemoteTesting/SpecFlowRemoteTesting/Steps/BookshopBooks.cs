using SpecFlowRemoteTesting.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowRemoteTesting.Steps;

[Binding]
public class BookshopBooks
{
    private readonly BookShopPageObject _bookShopPageObject;

    public BookshopBooks(ChromeBrowserDriver chromeBrowserDriver) =>
        _bookShopPageObject = new BookShopPageObject(chromeBrowserDriver.Current);

    [Given(@"Jan, a software engineer, wants to buy new books about software development")]
    [Given(@"Kelly, a mother that wants to buy a book for her daughter")]
    public void GivenJanASoftwareEngineerWantsToBuyNewBooksAboutSoftwareDevelopment()
    {
    }

    [When(@"he opens the bookshop's website")]
    [When(@"she opens the bookshop's website")]
    public void WhenHeOpensTheBookshopsWebsite()
    {
        _bookShopPageObject.EnsurePageIsOpenAndReady();
    }

    [When(@"he searches for books about '(.*)'")]
    [When(@"she searches for books about '(.*)'")]
    public void WhenHeSearchesForBooksAbout(string searchString)
    {
        _bookShopPageObject.EnterSearchText(searchString);
        _bookShopPageObject.SubmitSearchText();
    }
    
    [Then(@"he will find no books he can buy")]
    public void ThenHeWillFindNoBooksHeCanBuy()
    {
        var actualResult = _bookShopPageObject.WaitForNonEmptyResult();
        Assert.Equal("Resultaten (0)", actualResult);
    }

    [Then(@"she will find books she can buy")]
    public void ThenSheWillFindBooksSheCanBuy()
    { 
        var actualResult = _bookShopPageObject.WaitForNonEmptyResult();
        Assert.Matches("Resultaten \\(\\d+\\)", actualResult);
    }
}