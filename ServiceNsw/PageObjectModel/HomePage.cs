using OpenQA.Selenium;
using System;

namespace ServiceNsw.PageObjectModel
{
    class HomePage
    {
        private readonly IWebDriver _driver;

        //POM
        private readonly By _searchBar = By.Id("edit-contains");
        private readonly By _searchResultItems = By.CssSelector("#ui-id-1 > li > a");
        private readonly By _searchButton = By.Id("edit-submit-site-search");
        private readonly By _locateUs = By.ClassName("locate-us-button");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SearchAnItem(string searchInput)
        {
           IWebElement _element = _driver.FindElement(_searchBar);
           _element.Click();
           _element.SendKeys(searchInput);
           _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
           var _searchResults = _driver.FindElements(_searchResultItems);
           var _searchResultItemsCount = _searchResults.Count;
           
           if(_searchResultItemsCount ==1)
           {
               if (_searchResults[0].GetAttribute("innerHTML").Trim() == searchInput)
               {
                   _searchResults[0].Click();                        
               }               
           }
           else
           {
               _driver.FindElement(_searchButton).Click();
           }

        }

        public void ClickOnLocateUsButton()
        {
            _driver.FindElement(_locateUs).Click();
        }

    }
}