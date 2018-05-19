using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.SpecFlowEx.Test.Models;

namespace CP.SpecFlowEx.Test.Services
{
    public abstract class EntitiesStepsBase<TEntity, TTestModel> : StepsBase
        where TEntity : class
        where TTestModel : class, ITestModel<TEntity>
    {
        protected List<TTestModel> list = new List<TTestModel>();

        public EntitiesStepsBase(BaseTestData data) : base(data)
        {
            Fixture.Register(() => list);
            Fixture.Register(() => list.Select(tm => tm.Entity));
        }
    }
}
