using TechTalk.SpecFlow;

namespace ServiceNsw.Helper
{
    [Binding]
    public sealed class FeatureSetup
    {
        [BeforeFeature]
        private static void InitializeBrowser(FeatureContext featureContext)
        {   
            var _driver = new Driver();
            _driver.Initialize();
            featureContext.Set(_driver, Constants.FeatureInstance);

        }

        [AfterFeature]
        private static void BrowserCleanup(FeatureContext featureContext)
        {
            featureContext.Get<Driver>(Constants.FeatureInstance).Close();
            featureContext.Get<Driver>(Constants.FeatureInstance).Quit();
        }
    }
}
