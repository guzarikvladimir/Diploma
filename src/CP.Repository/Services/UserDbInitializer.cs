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
            Guid userId = Guid.NewGuid();
            Guid roleId = Guid.NewGuid();
            Guid employeeRoleId = Guid.NewGuid();
            var role = new Role { Id = roleId, Name = "Human Resource" };
            var employee = new Employee()
            {
                Id = userId,
                Name = "Ivan"
            };
            var employeeRole = new EmployeeRole()
            {
                Id = employeeRoleId,
                EmployeeId = userId,
                RoleId = roleId
            };
            var user = new User
            {
                Id = userId,
                Password = "123456"
            };
            var employee2 = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            };

            db.Roles.Add(role);
            db.Employees.Add(employee);
            db.Employees.Add(employee2);
            db.Users.Add(user);
            db.EmployeeRoles.Add(employeeRole);

            base.Seed(db);
        }
    }
}