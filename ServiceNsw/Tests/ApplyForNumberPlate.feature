Feature: ApplyForNumberPlate
Verify the navigation of Apply for a number plate search item

@ServiceNsw
Scenario: Apply for a number plate with location.
	Given Open the home page in the browser.
	And I search for "Apply for a number plate" in the search bar.
	Then The page should be successfully loaded with title "Apply for a number plate | Service NSW".



																																			