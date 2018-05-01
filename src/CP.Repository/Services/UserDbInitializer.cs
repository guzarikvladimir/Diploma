using System;
using System.Collections.Generic;
using System.Data.Entity;
using CP.Repository.Models;

namespace CP.Repository.Services
{
    public class UserDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            AddEmployee(db);
            AddCurrencies(db);

            base.Seed(db);
        }

        private void AddEmployee(ApplicationContext db)
        {
            Guid positionId = Guid.NewGuid();
            var position = new JobFunctionPosition()
            {
                Id = positionId,
                Name = "Software Engineer"
            };
            db.JobFunctionPositions.Add(position);

            Guid titleId = Guid.NewGuid();
            var title = new JobFunctionTitle()
            {
                Id = titleId,
                Name = "Senior"
            };
            db.JobFunctionTitles.Add(title);

            Guid jobFunctionId = Guid.NewGuid();
            var jobFunction = new JobFunction()
            {
                Id = jobFunctionId,
                JobFunctionTitle = title,
                TitleId = titleId,
                JobFunctionPosition = position,
                PositionId = positionId
            };
            db.JobFunctions.Add(jobFunction);

            Guid employeeStatusId = Guid.NewGuid();
            var employeeStatus = new EmployeeStatus()
            {
                Id = employeeStatusId,
                Name = "Employee"
            };
            db.EmployeeStatuses.Add(employeeStatus);

            Guid countryId = Guid.NewGuid();
            var country = new Country()
            {
                Id = countryId,
                Name = "Belarus"
            };
            db.Countries.Add(country);

            Guid locationId = Guid.NewGuid();
            var location = new Location()
            {
                Id = locationId,
                Name = "Minsk",
                CountryId = countryId
            };
            db.Locations.Add(location);

            Guid roleId = Guid.NewGuid();
            var role = new Role
            {
                Id = roleId,
                Name = "Human Resource"
            };
            db.Roles.Add(role);

            Guid userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Password = "123456"
            };
            db.Users.Add(user);

            Guid employeeRoleId = Guid.NewGuid();
            var employee = new Employee()
            {
                Id = userId,
                Name = "Ivan",
                LocationId = locationId,
                StatusId = employeeStatusId,
                EmployeeStatus = employeeStatus,
                JobFunctionId = jobFunctionId
            };
            db.Employees.Add(employee);

            var employeeRole = new EmployeeRole()
            {
                Id = employeeRoleId,
                EmployeeId = userId,
                RoleId = roleId
            };
            db.EmployeeRoles.Add(employeeRole);
        }

        private void AddCurrencies(ApplicationContext db)
        {
            Guid usdId = Guid.NewGuid();
            Guid eurId = Guid.NewGuid();
            Guid byrId = Guid.NewGuid();
            Guid rurId = Guid.NewGuid();
            db.Currencies.AddRange(new List<Currency>()
            {
                new Currency()
                {
                    Id = usdId,
                    Name = "USD"
                },
                new Currency()
                {
                    Id = eurId,
                    Name = "EUR"
                },
                new Currency()
                {
                    Id = byrId,
                    Name = "BYR"
                },
                new Currency()
                {
                    Id = rurId,
                    Name = "RUR"
                }
            });

            db.CurrencyRates.AddRange(new List<CurrencyRate>()
            {
                new CurrencyRate()
                {
                    Id = Guid.NewGuid(),
                    CurrencyId = usdId,
                    Date = new DateTime(2018, 4, 1),
                    Ratio = decimal.Parse("1.0"),
                    Type = CurrencyRateType.Daily
                },
                new CurrencyRate()
                {
                    Id = Guid.NewGuid(),
                    CurrencyId = eurId,
                    Date = new DateTime(2018, 4, 1),
                    Ratio = decimal.Parse("0.821"),
                    Type = CurrencyRateType.Daily
                },
                new CurrencyRate()
                {
                    Id = Guid.NewGuid(),
                    CurrencyId = byrId,
                    Date = new DateTime(2018, 4, 1),
                    Ratio = decimal.Parse("2.0"),
                    Type = CurrencyRateType.Daily
                },
                new CurrencyRate()
                {
                    Id = Guid.NewGuid(),
                    CurrencyId = rurId,
                    Date = new DateTime(2018, 4, 1),
                    Ratio = decimal.Parse("61.8"),
                    Type = CurrencyRateType.Daily
                }
            });
        }
    }
}