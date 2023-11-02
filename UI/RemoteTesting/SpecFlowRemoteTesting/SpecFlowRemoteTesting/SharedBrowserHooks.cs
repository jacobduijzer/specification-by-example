using BoDi;
using TechTalk.SpecFlow;

namespace SpecFlowRemoteTesting;

[Binding]
public class SharedBrowserHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun(ObjectContainer testThreadContainer)
    {
        testThreadContainer.BaseContainer.Resolve<ChromeBrowserDriver>();
    }
}