using System;
using AutoFixture;
using CP.Platform.Test.Core.Models;

namespace CP.Platform.Test.Core.Services
{
    public abstract class EntityStepsBase<TEntity> : StepsBase
        where TEntity : class
    {
        protected IFixture fixtureWithoutConfiguration = new Fixture();
        protected FunctionWrapper<Func<TEntity>> GetEntityFunction { get; private set; }

        public EntityStepsBase(BaseTestData data) : base(data)
        {
            GetEntityFunction = new FunctionWrapper<Func<TEntity>>(() => CreateEntity(Fixture));
            Fixture.Register(GetEntityFunction.FunctionInvoker);
        }

        protected virtual TEntity CreateEntity(IFixture fixture)
        {
            return fixtureWithoutConfiguration.Create<TEntity>();
        }
    }
}
