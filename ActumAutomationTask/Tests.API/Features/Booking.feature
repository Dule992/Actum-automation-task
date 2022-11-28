Feature: Booking

Scenario: 01 Create a new booking
	Given Request body is prepared with valid data
	When Request is sent to create a booking
	Then Response should be 200 and OK

Scenario: 02 Get existing booking
	Given Request body is prepared with valid data
	When Request is sent to get a booking
	Then Response should be 200 and OK
	And Response data corresponds with created data

Scenario: 03 Update existing booking
	Given Request is sent to get a token
	And Request body is prepared with valid data
	When Request is sent to update a booking
	Then Response should be 200 and OK
	And Response data corresponds with updated data

Scenario: 04 Delete existing booking
	Given Request is sent to get a token
	When Request is sent to delete a booking
	Then Response should be 201 and Created
	And Response for checking deleted booking should be 404 and Not Found
