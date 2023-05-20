using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlBinaryExpression : SqlExpression
{
    public SqlBinaryExpression(SqlExpression left, SqlExpression right, SqlBinaryOperator @operator)
    {
        Left = left;
        Right = right;
        Operator = @operator;
    }
    
    public SqlExpression Left { get; set; }
    public SqlExpression Right { get; set; }
    public SqlBinaryOperator Operator { get; set; }
    public override string Accept(ISqlVisitor visitor)
    {
        return visitor.Visit(this);
    }
}