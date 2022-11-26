Feature: Login

@regression @headlessMode
Scenario: 01 Login with existing user
	Given User opened the home page
	When User filled the login form with username and password
	Then Label with username is shown in menu bar

@smoke @headlessMode	
Scenario: 02 Login with not existing user
	Given User opened the home page
	When User filled the login form with not existing username and password
	Then Validation message User does not exist. is presented
