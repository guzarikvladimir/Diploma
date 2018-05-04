Feature: CompensationCalculationService. GetForCompensations
Background: 
	Given Requestor is going to calculate compensations
	And Request time is configured to be 2018-05-02
	And Currencies are customized to have properties
	| Name |
	| USD  |
	| EUR  |
	| BYR  |

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

Scenario: Multiple currencies
	Given Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | ApplyDate  | SalaryType |
	| Salary_1 | 100   | USD      | Salary        | 2018-05-02 | Monthly    |
	| Salary_2 | 100   | BYR      | Salary        | 2018-04-02 | Annual     |
	| Salary_3 | 100   | EUR      | Salary        | 2018-03-02 | Annual     |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | 2018-04-02 |
	And CurrencyRates are customized to have properties
	| Currency | Ratio | Type  | Date       |
	| USD      | 1.0   | Daily | 2018-05-02 |
	| BYR      | 2.0   | Daily | 2018-05-02 |
	| EUR      | 1.25  | Daily | 2018-05-02 |
	When Calculate compensations is requested
	Then Total value should be 1630
	And Result currency should be USD