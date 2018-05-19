using System.Collections.Generic;
using AutoFixture;
using CP.SpecFlowEx.Test.Models;

namespace CP.SpecFlowEx.Test.Services
{
    public abstract class EntityStepsBase<TEntity> : StepsBase
        where TEntity : class
    {
        protected List<TEntity> list = new List<TEntity>();

        public EntityStepsBase(BaseTestData data) : base(data)
        {
            Fixture.Register(() => list);
        }
    }
}
