Feature: SearchServiceCentre
Search for a service centre using locate us button and verify the desired centre in the webpage.

@service_cente
Scenario Outline: Locate service centre
Given Open the home page in the browser.
	Given I click the LocateUs button.
	And I search for "<Search_Item>" service centre.
	Then The service location "<Search_Result>" should be listed in the page.

	Examples:
	| Id | TestCaseName | Search_Item                  | Search_Result                                   |
	| 1  | TC_001       | Sydney 2000                  | Wynyard Service Centre                          |
	| 2  | TC_002       | Newtown 2042                 | Marrickville Service Centre                     |
	| 3  | TC_003       | Sydney Domestic Airport 2020 | Botany Service Centre,Rockdale Service Centre   |
	| 4  | TC_004       | Surry Hills 2010             | Haymarket Service Centre,Wynyard Service Centre |
