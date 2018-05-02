using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Models;

namespace CP.Platform.Test.Core.Services
{
    public abstract class EntitiesStepsBase<TEntity, TTestModel> : StepsBase
        where TEntity : class
        where TTestModel : class, ITestModel<TEntity>
    {
        //protected IFixture fixtureWithoutConfiguration = new Fixture();
        //protected List<TEntity> createdEntities = new List<TEntity>();

        //protected FunctionWrapper<Func<TEntity>> GetEntityFunction { get; private set; }
        //protected FunctionWrapper<Func<List<TEntity>>> GetEntitiesFunction { get; private set; }

        protected List<TTestModel> list = new List<TTestModel>();

        public EntitiesStepsBase(BaseTestData data) : base(data)
        {
            //GetEntityFunction = new FunctionWrapper<Func<TEntity>>(() => CreateEntity(Fixture));
            //Fixture.Register(GetEntityFunction.FunctionInvoker);

            //GetEntitiesFunction = new FunctionWrapper<Func<List<TEntity>>>(() => createdEntities);
            //Fixture.Register(GetEntitiesFunction.FunctionInvoker);

            Fixture.Register(() => list);
            Fixture.Register(() => list.Select(tm => tm.Entity));
        }

        //protected virtual TEntity CreateEntity(IFixture fixture)
        //{
        //    TEntity entity = fixtureWithoutConfiguration.Create<TEntity>();
        //    createdEntities.Add(entity);

        //    return entity;
        //}
    }
}
