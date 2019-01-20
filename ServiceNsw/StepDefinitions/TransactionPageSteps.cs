using NUnit.Framework;
using ServiceNsw.Helper;
using ServiceNsw.Properties;
using TechTalk.SpecFlow;

namespace ServiceNsw.StepDefinitions
{
    [Binding]
    public sealed class TransactionPageSteps
    {
        private readonly Driver _driver;

        public TransactionPageSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<Driver>(Constants.Driver);
        }

        [Then(@"The page should be successfully loaded with title ""(.*)""\.")]
        public void ThenThePageShouldBeSuccessfullyLoadedWithTitle_(string expectedPageTitle)
        {
            var actualPageTitle = _driver.Instance.Title;
            Assert.IsTrue(expectedPageTitle == actualPageTitle, string.Format(Resource.Err_2_Title_NotFound, expectedPageTitle, actualPageTitle));
            _driver.GoTo();
        }
    }
}
