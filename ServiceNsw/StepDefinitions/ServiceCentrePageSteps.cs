using System;
using NUnit.Framework;
using ServiceNsw.Helper;
using ServiceNsw.PageObjectModel;
using ServiceNsw.Properties;
using TechTalk.SpecFlow;

namespace ServiceNsw.StepDefinitions
{
    [Binding]
    public sealed class ServiceCentrePageSteps
    {
        private readonly ServiceCentrePage _serviceCentrePage;
        private readonly Driver _driver;

        public ServiceCentrePageSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<Driver>(Constants.Driver);
            _serviceCentrePage = new ServiceCentrePage(_driver.Instance);
        }

        [Given(@"I search for ""(.*)"" service centre\.")]
        public void GivenISearchForServiceCentre_(string serviceCentre)
        {
            _serviceCentrePage.EnterSearchTextAndClick(serviceCentre);
            _driver.Wait(TimeSpan.FromSeconds(2));
        }

        [Then(@"The service location ""(.*)"" should be listed in the page\.")]
        public void ThenTheServiceLocationShouldBeListedInThePage_(string serviceCentre)
        {
            foreach (var item in serviceCentre.Split(','))
            {
                var result = _serviceCentrePage.HasServiceLocation(item);
                Assert.IsTrue(result, string.Format(Resource.Err_1_Svc_NotFound, item));
            }
        }

    }
}
