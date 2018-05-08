using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Test.Contract.EmployeeToLegalEntity.Helpers;
using CP.Shared.Test.Contract.EmployeeToLegalEntity.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.EmployeeToLegalEntity.Customizations
{
    [Binding]
    public class EmployeeToLegalEntityViewSteps : EntityStepsBase<EmployeeToLegalEntityView>
    {
        public EmployeeToLegalEntityViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Employees are customized to have legal entities")]
        public void GivenEmployeeToLegalEntitiesAreCustomizedToHaveProperties(Table table)
        {
            foreach (var model in table.CreateSet<EmployeeToLegalEntityViewCustomizationModel>())
            {
                EmployeeToLegalEntityView employeeToLegalEntity = Fixture.Create<EmployeeToLegalEntityView>();
                EmployeeToLegalEntityHelper.Map(Fixture, model, employeeToLegalEntity);
                list.Add(employeeToLegalEntity);
            }
        }
    }
}