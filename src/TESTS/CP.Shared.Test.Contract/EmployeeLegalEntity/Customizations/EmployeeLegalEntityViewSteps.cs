using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Test.Contract.EmployeeLegalEntity.Helpers;
using CP.Shared.Test.Contract.EmployeeLegalEntity.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.EmployeeLegalEntity.Customizations
{
    [Binding]
    public class EmployeeLegalEntityViewSteps : EntityStepsBase<EmployeeLegalEntityView>
    {
        public EmployeeLegalEntityViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Employees are customized to have legal entities")]
        public void GivenEmployeeToLegalEntitiesAreCustomizedToHaveProperties(Table table)
        {
            foreach (var model in table.CreateSet<EmployeeLegalEntityViewCustomizationModel>())
            {
                EmployeeLegalEntityView employeeLegalEntity = Fixture.Create<EmployeeLegalEntityView>();
                EmployeeLegalEntityHelper.Map(Fixture, model, employeeLegalEntity);
                list.Add(employeeLegalEntity);
            }
        }
    }
}