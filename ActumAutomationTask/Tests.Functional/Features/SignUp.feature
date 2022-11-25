Feature: Sign Up

Scenario: 01 Create account with new user
	Given User opened the home page
	When User filled the sign up form with new username and password
	Then Validation message Sign up successful. is presented

Scenario: 02 Create account with existing user
	Given User opened the home page
	When User filled the sign up form with existing username and password
	Then Validation message This user already exist. is presented

Scenario: 03 Create account with missing credentials
	Given User opened the home page
	When User filled the sign up form with missing <username> and <password>
	Then Validation message Please fill out Username and Password. is presented
Scenarios:
	| username | password |
	| test     |          |
	|          | test     |