
# Service Nsw Tests

This is a C# selenium Nunit test framework which runs the service NSW tests in chrome browser. It is easy customization to run on any test environments on any browser.

The framework is designed to run on **parallel multi threaded execution** which effectively uses Specflow's thread safe Scenario and feature context injections.

The repo is shipped with Nunit Gui hence without requiring visual studio the tests can be executed. 

***Framework design***

The framework is a 3 tier architecture which leverages the selenium's page object model, specflow BDD/Gherkin files and framework driver itself.

The tier one will be BDD file which is bonded to Step definition.

Step definition talks to Page object model to interact with HTML elements in the web-page which also holds the element identifiers. 

The driver class is the object which drives the interaction with the web-page and page object model.

Each web-page will have a corresponding step definition class and a page object model class which is designed for easy understanding/debugging and maintenance.  

The data that needs to shared across step definitions are achieved by Scenario Context and data across feature files are done through Feature Context. 

All the necessary dependencies are managed using Nuget hence no extra drivers/files or dlls required to run the tests. 

***App.cofig***

 1. Specify the environment in currentEnviorment variable like Test or
        UAT or Prod
  2. List the URLS in Test_url or UAT_url   
  3. Default web  page load time out is 10 seconds
  4. Screenshots are stored in the folder ErrorScreenShot under the repo. Screenshots capture can be activated or deactivated using the flag TakeScreenShotOnError
  
***Test Execution***

In order to execute the test. The test machine should have the latest .netframework or if you are executing in Windows 10 it should work as is.
If you dont have visual studio then you can use the CommandLineBuildAndExecute.bat which would build the solution and run the tests. 
The results are available in TestResult.xml post execution under solution folder.


