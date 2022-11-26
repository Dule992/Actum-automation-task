Feature: Categories

Scenario: 01 List of phones items in categories
	Given User opened the home page
	When User click on the Phones filter
	Then User should see 7 items in product store

Scenario: 02 List of laptops items in categories
	Given User opened the home page
	When User click on the Laptops filter
	Then User should see 12 items in product store

Scenario: 03 List of monitors items in categories
	Given User opened the home page
	When User click on the Monitors filter
	Then User should see 2 items in product store