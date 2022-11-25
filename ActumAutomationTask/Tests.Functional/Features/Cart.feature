Feature: Cart

Scenario: 01 Place order one item from Product Store
	Given User opened the home page
	And User pick 1 item
	And User put item in a cart
	And User opened the cart page
	When User filled the place order form with valid data
	Then Validation message Sign up successful. is presented
