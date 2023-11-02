using SpecFlowRemoteTesting.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowRemoteTesting;

[Binding]
public class BookshopBooksHooks 
{
    ///<summary>
    ///  Reset the calculator before each scenario tagged with "Calculator"
    /// </summary>
    [BeforeScenario("BookshopBooks")]
    public static void BeforeScenario(ChromeBrowserDriver browserDriver)
    {
        var bookshopPageObject = new BookShopPageObject(browserDriver.Current);
        bookshopPageObject.EnsureCalculatorIsOpenAndReset();
    }
}