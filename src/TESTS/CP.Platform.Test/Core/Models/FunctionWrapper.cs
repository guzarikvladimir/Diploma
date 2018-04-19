using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CP.Platform.Test.Core.Models
{
    public class FunctionWrapper<TFunc>
        where TFunc : class
    {
        private TFunc function;
        private Lazy<TFunc> functionInvoker;

        public TFunc FunctionInvoker => functionInvoker.Value;

        public FunctionWrapper(TFunc function) : this()
        {
            this.function = function;
        }

        public FunctionWrapper()
        {
            functionInvoker = new Lazy<TFunc>(GetFunctionInvoker);
        }

        public void Set(TFunc newFunction)
        {
            function = newFunction;
        }

        public void Update(Func<TFunc, TFunc> updateLogic)
        {
            function = updateLogic(function);
        }

        private TFunc GetFunctionInvoker()
        {
            ParameterExpression[] parameters = GetParameters();
            FieldInfo functionField =
                GetType().GetField(nameof(function), BindingFlags.NonPublic | BindingFlags.Instance);
            MemberExpression functionFieldExpression = Expression.Field(Expression.Constant(this), functionField);

            return Expression.Lambda<TFunc>(Expression.Invoke(functionFieldExpression, parameters), parameters)
                .Compile();
        }

        private ParameterExpression[] GetParameters()
        {
            Type[] parameters = typeof(TFunc).GetGenericArguments();

            return parameters.Take(parameters.Length - 1)
                .Select(type => Expression.Parameter(type))
                .ToArray();
        }
    }
}