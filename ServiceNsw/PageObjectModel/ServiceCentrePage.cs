using OpenQA.Selenium;
using System.Linq;

namespace ServiceNsw.PageObjectModel
{
    class ServiceCentrePage
    {
        private readonly IWebDriver _driver;
        private readonly By _locatorTextSearch = By.Id("locatorTextSearch");
        private readonly By _searchButton = By.XPath("//button[@class='button button--primary button--xxlarge button--search button--icon']");
        private readonly By _locationCard = By.ClassName("location__title");

        public ServiceCentrePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterSearchTextAndClick(string textInput)
        {
            var _searchArea = _driver.FindElement(_locatorTextSearch);
            _searchArea.Click();
            _searchArea.Clear();
            _searchArea.SendKeys(textInput);
            _driver.FindElement(_searchButton).Click();
        }

        public bool HasServiceLocation(string serviceLocation)
        {  
            var _serviceLocationList = _driver.FindElements(_locationCard);
            return _serviceLocationList.Any(s => s.Text == serviceLocation);            
        }
    }
}
