using System.Collections.Generic;
using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Employee.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.Employee.Customizations
{
    [Binding]
    public class EmployeeViewSteps : EntityStepsBase<EmployeeView>
    {
        List<EmployeeView> employees = new List<EmployeeView>();

        public EmployeeViewSteps(BaseTestData data) : base(data)
        {
            Fixture.Register(() => employees);
        }

        [Given(@"Employees are configured to have properties")]
        public void GivenEmployeesAreConfiguredToHaveProperties(Table table)
        {
            foreach (EmployeeView model in table.CreateSet<EmployeeView>())
            {
                EmployeeView employee = Fixture.Create<EmployeeView>();
                employee.Name = model.Name;
                employees.Add(employee);
            }
        }
    }
}