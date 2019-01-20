using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace ServiceNsw.Helper
{
    [Binding]
    public static class TestSetup
    {
        private const string ChromeDriver = "chromedriver";
        private const string ScreenShotFolder = "ScreenShotFolder";
        public static string ScreenShotFolderPath;

        [BeforeTestRun]
        private static void InitializeDriver()
        {
            ScreenShotDirectoryCleanup();

            Process[] chromeDriverProcesses = Process.GetProcessesByName(ChromeDriver);

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }

        private static void ScreenShotDirectoryCleanup()
        {
            var _directoryInfo = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent;
            if (_directoryInfo?.Parent != null)
            {
                var _rootDirectory = _directoryInfo.Parent.FullName;
                ScreenShotFolderPath = _rootDirectory + "\\" + ConfigurationManager.AppSettings[ScreenShotFolder] + "\\";
            }

            var folderExists = Directory.Exists(ScreenShotFolderPath);
            if (folderExists)
            {
                var di = new DirectoryInfo(ScreenShotFolderPath);
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }                
            }
            else
            {
                Directory.CreateDirectory(ScreenShotFolderPath);
            }            
        }
               
    }
}
