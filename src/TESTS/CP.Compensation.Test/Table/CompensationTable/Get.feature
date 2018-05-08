Feature: CompensationCalculationService. GetForCompensations
Background: 
	Given Requestor is going to get compensation table
	And Request time is configured to be 2018-05-02
	And Currencies are customized to have properties
	| Name |
	| USD  |
	| EUR  |
	| BYR  |
	| RUR  |
	And CurrencyRates are customized to have properties
	| Currency | Ratio | Type  | Date       |
	| USD      | 1.0   | Daily | 2018-05-02 |
	| BYR      | 2.0   | Daily | 2018-05-02 |
	| EUR      | 1.25  | Daily | 2018-05-02 |
	And LegalEntities are customized to have properties
	| Name   | Currency | IsActive |
	| LE BLR | BYR      | true     |
	| LE USA | USD      | true     |
	| LE RU  | RUR      | false    |
	And Employees are configured to have properties
	| Name       |
	| Employee_1 |
	And Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |

Scenario: All USD compensations
	Given Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Monthly    | 2018-05-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period     | Compensations | Total | Currency |
	| Employee_1 | 2018-05-01 | Salary_1      | 1200  | USD      |
	| Employee_1 | 2018-04-01 | Bonus_1       | 300   | USD      |
	And Employees totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 1500  | USD      |
	
Scenario: Multiple currencies
	Given Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Monthly    | 2018-05-02  |
	| Salary_2 | 100   | BYR      | Salary        | Approved        | Employee_1 | LE USA      | 2018-04-02 | Annual     | 2018-04-02  |
	| Salary_3 | 100   | EUR      | Salary        | Approved        | Employee_1 | LE USA      | 2018-03-02 | Annual     | 2018-03-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	When Compensation table is requested with parameters
	| Currency |
	| USD      |
	Then Employees compensations should be
	| Employee   | Period     | Compensations    | Total | Currency |
	| Employee_1 | 2018-03-01 | Salary_3         | 80    | USD      |
	| Employee_1 | 2018-04-01 | Salary_2,Bonus_1 | 350   | USD      |
	| Employee_1 | 2018-05-01 | Salary_1         | 1200  | USD      |
	And Employees totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 1630  | USD      |