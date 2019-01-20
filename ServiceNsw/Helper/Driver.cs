using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace ServiceNsw.Helper
{
    public class Driver
    {
        private const string DefaultTimeoutString = "DefaultTimeOutInSeconds";
        private const string HomePageIdentifier = "a > div.site-logo";
        private const string CurrentEnvironment = "currentEnviorment";
        private const string Url = "_Url";
        private const string DisableExtension = "--disable-extensions";

        private int DefaultTimeOut
        {
           get
            {
                var defaultTimeOut = ConfigurationManager.AppSettings[DefaultTimeoutString];
                return Convert.ToInt32(defaultTimeOut);
            }
        }

        public string HomePageXpath => HomePageIdentifier;

        public IWebDriver Instance { get; set; }

        private ChromeOptions Options { get; set; }

        public void Initialize()
        {
            Instance = new ChromeDriver();
            Options = new ChromeOptions();
            Options.AddArguments(DisableExtension);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultTimeOut);
            Instance.Manage().Window.Maximize();
        }

        public void Close()
        {
            Instance.Close();            
        }

        public void Quit()
        {
            Instance.Quit();
        }

        public void GoTo()
        {
            var currentEnvironment = ConfigurationManager.AppSettings[CurrentEnvironment];
            var currentEnvironmentUrl = ConfigurationManager.AppSettings[currentEnvironment + Url];
            Instance.Navigate().GoToUrl(currentEnvironmentUrl);
            WaitUntilPageLoad(By.CssSelector(HomePageXpath));
        }

        public void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public void WaitUntilPageLoad(By by)
        {
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(DefaultTimeOut));
            wait.Until(d => d.FindElement(by));     
        }

    }
}
