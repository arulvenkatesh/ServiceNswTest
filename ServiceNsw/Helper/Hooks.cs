using NUnit.Framework;
using OpenQA.Selenium;
using ServiceNsw.Properties;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace ServiceNsw.Helper
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext,FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }        


        [BeforeScenario]
        private void InitializeBrowser()
        {
            var _featureDriver = _featureContext.Get<Driver>(Constants.FeatureInstance);            
            try
            {
                _featureDriver.GoTo();
                _scenarioContext.Set(_featureDriver, Constants.Driver);
            }
            catch (Exception ex)
            {
                Assert.Fail(Resource.Exc_1_WebDriver_Intialize, ex.InnerException);
            }
        }

        [AfterScenario]
        private void TeardownBrowser()
        {
            var _driver = _scenarioContext.Get<Driver>(Constants.Driver);            
            if ((_scenarioContext.ScenarioExecutionStatus.ToString() != "OK") && ConfigurationManager.AppSettings["TakeScreenShotOnError"].ToUpper() =="TRUE")
            {
                Screenshot _screenshots = ((ITakesScreenshot)_driver.Instance).GetScreenshot();
                var _title = _scenarioContext.ScenarioInfo.Title;
                var _runName = _title + DateTime.Now.ToString("_yyyy-MM-dd-HH_mm_ss");
                
                _screenshots.SaveAsFile(TestSetup.ScreenShotFolderPath +"\\"+ _title + _runName + ".png", ScreenshotImageFormat.Png);

            }
        }

    }
}
