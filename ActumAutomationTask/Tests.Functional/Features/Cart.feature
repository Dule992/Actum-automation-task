Feature: Cart

@regression
Scenario: 01 Placing order one item from Product Store
	Given User opened the home page
	And User pick 1 item and put item in a cart
	And Validation message Product added is presented
	And User opened the cart page
	And User see the item in cart
	When User filled the place order form with valid data
	Then Receipt message Thank you for your purchase! is presented
