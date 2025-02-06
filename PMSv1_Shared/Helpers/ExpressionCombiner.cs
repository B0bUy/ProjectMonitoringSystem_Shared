using System.Linq.Expressions;

public static class ExpressionCombiner
{
    // Combine multiple expressions using AND
    public static Expression<Func<T, bool>> CombineAnd<T>(IEnumerable<Expression<Func<T, bool>>> expressions)
    {
        if (expressions == null || !expressions.Any())
            return x => true; // Default to "true" if no expressions are provided

        // Start with the first expression
        var parameter = Expression.Parameter(typeof(T), "x");
        var combinedBody = ReplaceParameter(expressions.First().Body, expressions.First().Parameters[0], parameter);

        // Combine the rest of the expressions
        foreach (var expr in expressions.Skip(1))
        {
            var body = ReplaceParameter(expr.Body, expr.Parameters[0], parameter);
            combinedBody = Expression.AndAlso(combinedBody, body);
        }

        // Return the combined expression
        return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
    }

    private static Expression ReplaceParameter(Expression expression, ParameterExpression oldParameter, ParameterExpression newParameter)
    {
        return new ParameterReplacer { OldParameter = oldParameter, NewParameter = newParameter }.Visit(expression);
    }

    private class ParameterReplacer : ExpressionVisitor
    {
        public ParameterExpression OldParameter { get; set; }
        public ParameterExpression NewParameter { get; set; }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == OldParameter ? NewParameter : base.VisitParameter(node);
        }
    }
}