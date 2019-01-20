using NUnit.Framework;
using ServiceNsw.Helper;
using ServiceNsw.PageObjectModel;
using TechTalk.SpecFlow;

namespace ServiceNsw.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly Driver _driver;
        private readonly HomePage _homePagePom;
        private const string HomePageTitle = "Home | Service NSW";

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<Driver>(Constants.Driver);
            _homePagePom = new HomePage(_driver.Instance);            
        }

        [Given(@"Open the home page in the browser\.")]
        public void GivenOpenTheHomePageInTheBrowser_()
        {   
            var actualHomePageTitle = _driver.Instance.Title;
            Assert.IsTrue(HomePageTitle == actualHomePageTitle,"ChromeDriver is not in homepage");
        }

        [Given(@"I search for ""(.*)"" in the search bar\.")]
        public void GivenISearchForInTheSearchBar(string searchInput)
        {
            _homePagePom.SearchAnItem(searchInput);
        }

        [Given(@"I click the LocateUs button\.")]
        public void GivenIClickTheLocateUsButton_()
        {
            _homePagePom.ClickOnLocateUsButton();
        }

    }
}
