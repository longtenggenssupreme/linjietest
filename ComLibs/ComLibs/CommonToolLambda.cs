using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public static class CommonToolLambda
    {

    }

    #region lambda expression 拼接方式1
    /// <summary>
    /// Expression表达式树
    /// </summary>
    public class LambdaParameteRebinder : ExpressionVisitor
    {
        /// <summary>
        /// 存放表达式树的参数的字典
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map"></param>
        public LambdaParameteRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 重载参数访问的方法，访问表达式树参数，如果字典中包含，则取出
        /// </summary>
        /// <param name="node">表达式树参数</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (map.TryGetValue(node, out ParameterExpression expression))
            {
                node = expression;
            }
            return base.VisitParameter(node);
        }

        public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new LambdaParameteRebinder(map).Visit(exp);
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExtension
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="merge"></param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var parameterMap = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = LambdaParameteRebinder.ReplaceParameter(parameterMap, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() => f => false;

        /// <summary>
        /// Expression表达式树lambda参数拼接-true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() => f => true;

        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);
    }
    #endregion

    #region lambda expression 拼接方式2
    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法扩展类
    /// </summary>
    public class LambdaExpressionParameter : ExpressionVisitor
    {
        /// <summary>
        /// 表达式数的lambda参数
        /// </summary>
        public ParameterExpression parameterExpression { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameterExpression"></param>
        public LambdaExpressionParameter(ParameterExpression parameterExpression)
        {
            this.parameterExpression = parameterExpression;
        }

        /// <summary>
        /// 替代方法
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Expression Replace(Expression expression)
        {
            return base.Visit(expression);
        }

        /// <summary>
        /// 重载参数访问的方法，处理参数表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.parameterExpression;
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExpressionExtend
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not1<T>(this Expression<Func<T, bool>> expression)
        {
            var param = expression.Parameters[0];//指定参数和参数名称
                                                 //var param = Expression.Parameter(typeof(T), "w");
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
    #endregion
}
