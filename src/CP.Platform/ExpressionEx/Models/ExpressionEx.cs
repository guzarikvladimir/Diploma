using System;
using System.Linq.Expressions;
using SystemExpression = System.Linq.Expressions.Expression;

namespace CP.Platform.ExpressionEx.Models
{
    public class ExpressionEx<T>
    {
        private readonly Expression<Func<T, bool>> filter;

        public ExpressionEx(Expression<Func<T, bool>> filter)
        {
            this.filter = filter;
        }

        public Func<T, bool> Compile()
        {
            return filter.Compile();
        }

        public static ExpressionEx<T> And(ExpressionEx<T> left, ExpressionEx<T> right)
        {
            return new ExpressionEx<T>(SystemExpression.Lambda<Func<T, bool>>(SystemExpression.AndAlso(left.filter.Body, right.filter.Body)));
        }

        public static ExpressionEx<T> Or(ExpressionEx<T> left, ExpressionEx<T> right)
        {
            return new ExpressionEx<T>(SystemExpression.Lambda<Func<T, bool>>(SystemExpression.OrElse(left.filter.Body, right.filter.Body)));
        }
    }
}