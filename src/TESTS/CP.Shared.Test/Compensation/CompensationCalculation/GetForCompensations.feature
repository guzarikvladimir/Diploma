Feature: CompensationCalculationService. GetForCompensations
Background: 
	Given Requestor is going to calculate compensations
	And Currencies are customized to have properties
	| Name |
	| USD  |

Scenario: All USD compensations
	Given Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | ApplyDate  | SalaryType |
	| Salary_1 | 100   | USD      | Salary        | 2018-05-02 | Monthly    |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | 2018-04-02 |
	And CurrencyRates are customized to have properties
	| Currency | Ratio | Type    | Date       |
	| USD      | 1.0   | Daily   | 2018-05-02 |
	When Calculate compensations is requested
	Then Total value should be 1500
	And Result currency should be USD