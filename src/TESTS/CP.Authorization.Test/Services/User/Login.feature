Feature: UserService. Login
Background: 
	Given Requestor is going to be loginned

Scenario: User is registered
	Given Employees are configured to have properties
	| Name   |
	| User_1 |
	And Users are configured to have properties
	| Name   | Password |
	| User_1 | 123456   |
	When Login is requested with properties
	| Name   | Password |
	| User_1 | 123456   |
	Then User is loginned

Scenario: User is not registered
	Given Employees are configured to have properties
	| Name   |
	| User_1 |
	And Users are configured to have properties
	| Name   | Password |
	When Login is requested with properties
	| Name   | Password |
	| User_1 | 123456   |
	Then User is not loginned with message