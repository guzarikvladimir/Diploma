using CP.SpecFlowEx.Test.Models;

namespace CP.SpecFlowEx.Test.Services
{
    public abstract class ConfigurationStepsBase<TFunc> : StepsBase 
        where TFunc : class
    {
        protected FunctionWrapper<TFunc> MockFunction { get; private set; }

        public ConfigurationStepsBase(BaseTestData data) : base(data)
        {
            MockFunction = new FunctionWrapper<TFunc>(null);
        }
    }
}