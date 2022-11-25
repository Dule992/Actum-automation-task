Feature: Sign Up

Scenario: 01 Create account
	Given User opened the home page
	When User filled the sign up form with new username and password
	Then Validation message Sign up successful. is presented
	And Label with username is shown in menu bar

Scenario: 02 Create account with existing credentials
	Given User opened the home page
	When User filled the sign up form with existing username and password
	Then Validation message User is already exist is presented

Scenario: 03 Create account with missing credentials
	Given User opened the home page
	When User filled the sign up form with missing <username> and <password>
	Then Validation message Username and password needs to be filled out is presented
Scenarios:
	| username | password |
	| test     |          |
	|          | test     | 