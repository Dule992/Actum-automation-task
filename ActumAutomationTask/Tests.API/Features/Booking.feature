Feature: Booking

Scenario: 01 Create a new booking
	Given Request has authorized 
	When Request is sent to create a booking
	Then Response should be 200 and Success
	And Booking should be stored