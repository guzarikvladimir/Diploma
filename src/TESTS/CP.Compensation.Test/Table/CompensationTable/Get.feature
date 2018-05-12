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
	| RUR      | 60    | Daily | 2018-05-02 |
	And LegalEntities are customized to have properties
	| Name   | Currency | IsActive |
	| LE BLR | BYR      | true     |
	| LE USA | USD      | true     |
	| LE RU  | RUR      | false    |
	And Employees are configured to have properties
	| Name       |
	| Employee_1 |

Scenario Outline: Approved compensations of different salary types
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType   | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | <SalaryType> | 2018-05-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total         | Currency |
	| Employee_1 | 2018-05 | Salary_1      | <PeriodTotal> | USD      |
	| Employee_1 | 2018-04 | Bonus_1       | 300           | USD      |
	And Employee year totals should be
	| Employee   | Total           | Currency |
	| Employee_1 | <EmployeeTotal> | USD      |

Examples: 
	| SalaryType | PeriodTotal | EmployeeTotal |
	| Monthly    | 100         | 1500          |
	| Annual     | 100         | 400           |

Scenario: Rejected compensations
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Rejected        | Employee_1 | LE USA      | 2018-05-02 | Monthly    | 2018-05-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | Rejected        | Employee_1 | LE USA      | 2018-04-02 |
	And Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Compensations | Total | Currency |
	| Employee_1 | NULL          | NULL  | NULL     |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | NULL  | NULL     |

Scenario: Only salaries
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Monthly    | 2018-05-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-05 | Salary_1      | 100   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 1200  | USD      |

Scenario: Only bonuses
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-04 | Bonus_1       | 300   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 300   | USD      |

Scenario: Different periods
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-03-02 | Annual     | 2018-03-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 200   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	| Bonus_2 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-05-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-03 | Salary_1      | 100   | USD      |
	| Employee_1 | 2018-04 | Bonus_1       | 200   | USD      |
	| Employee_1 | 2018-05 | Bonus_2       | 300   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 600   | USD      |

Scenario: Future period
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-03-02 | Annual     | 2018-07-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations    | Total | Currency |
	| Employee_1 | 2018-03 | Salary_1         | 100   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 100   | USD      |

Scenario Outline: Next year compensations
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-03-02 | Annual     | 2018-03-02  |
	| Salary_2 | 200   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2019-04-02 | Annual     | 2018-04-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested with parameters
	| Year   |
	| <Year> |
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-03 | Salary_1      | 100   | USD      |
	| Employee_1 | 2019-04 | Salary_2      | 200   | USD      |
	And Employee year totals should be
	| Employee   | Total       | Currency |
	| Employee_1 | <YearTotal> | USD      |

Examples:
	| Year | YearTotal |
	| NULL | 100       |
	| 2019 | 200       |

Scenario: Different currencies for period - resolve with primary legal entity
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE BLR      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 100   | BYR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	| Bonus_2 | 200   | EUR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	| Bonus_3 | 300   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations           | Total | Currency |
	| Employee_1 | 2018-04 | Bonus_1,Bonus_2,Bonus_3 | 1020  | BYR      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 1020  | BYR      |

Scenario: Different currencies for period - resolve with defalut currency
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | false     |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 100   | BYR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-03-02 |
	| Bonus_2 | 200   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	| Bonus_3 | 300   | EUR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-05-02 |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-03 | Bonus_1       | 100   | BYR      |
	| Employee_1 | 2018-04 | Bonus_2       | 200   | USD      |
	| Employee_1 | 2018-05 | Bonus_3       | 300   | EUR      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 490   | USD      |

Scenario: Different currencies for period - resolve with requested currency
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | false     |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	| Bonus_1 | 100   | BYR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-03-02 |
	| Bonus_2 | 200   | USD      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-04-02 |
	| Bonus_3 | 300   | EUR      | Bonus         | Approved        | Employee_1 | LE USA      | 2018-05-02 |
	When Compensation table is requested with parameters
	| Currency |
	| EUR      |
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-03 | Bonus_1       | 62.5  | EUR      |
	| Employee_1 | 2018-04 | Bonus_2       | 250   | EUR      |
	| Employee_1 | 2018-05 | Bonus_3       | 300   | EUR      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 612.5 | EUR      |

Scenario: Multiple salaries in defferent periods - one legal entity
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-03-02 | Annual     | 2018-03-02  |
	| Salary_2 | 200   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-04-02 | Annual     | 2018-04-02  |
	| Salary_3 | 300   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Annual     | 2018-05-02  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations | Total | Currency |
	| Employee_1 | 2018-03 | Salary_1      | 100   | USD      |
	| Employee_1 | 2018-04 | Salary_2      | 200   | USD      |
	| Employee_1 | 2018-05 | Salary_3      | 300   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 300   | USD      |

Scenario: Multiple salaries in one period - one legal entity
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Annual     | 2018-04-01  |
	| Salary_2 | 200   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Annual     | 2018-04-02  |
	| Salary_3 | 300   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Annual     | 2018-04-03  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations              | Total | Currency |
	| Employee_1 | 2018-05 | Salary_1,Salary_2,Salary_3 | 300   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 300   | USD      |

Scenario: Multiple salaries in one period - multiple legal entities
	Given Employees are customized to have legal entities
	| Employee   | LegalEntity | IsPrimary |
	| Employee_1 | LE USA      | true      |
	| Employee_1 | LE BLR      | false     |
	And Salaries are customized to have properties
	| Name     | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  | SalaryType | CreatedDate |
	| Salary_1 | 100   | USD      | Salary        | Approved        | Employee_1 | LE USA      | 2018-05-02 | Annual     | 2018-04-01  |
	| Salary_2 | 200   | BYR      | Salary        | Approved        | Employee_1 | LE BLR      | 2018-05-02 | Annual     | 2018-04-02  |
	| Salary_3 | 300   | BYR      | Salary        | Approved        | Employee_1 | LE BLR      | 2018-05-02 | Annual     | 2018-04-03  |
	And Bonuses are customized to have properties
	| Name    | Value | Currency | PromotionType | PromotionStatus | Employee   | LegalEntity | ApplyDate  |
	When Compensation table is requested without parameters
	Then Employees compensations should be
	| Employee   | Period  | Compensations              | Total | Currency |
	| Employee_1 | 2018-05 | Salary_1,Salary_2,Salary_3 | 250   | USD      |
	And Employee year totals should be
	| Employee   | Total | Currency |
	| Employee_1 | 250   | USD      |