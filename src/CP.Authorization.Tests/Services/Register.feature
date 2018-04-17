Feature: UserService. Register
Background: 
	Given Requestor is going to be registered

Scenario: User 
	Given Requestor is configured to have properties
	| Name   |
	| User_1 |
	And Employees are configured to have properties
	| Name   |
	| User_1 |
	When Register is requested
	Then User is registered