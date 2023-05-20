using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlUnaryExpression : SqlExpression
{
    public SqlExpression Operand { get; set; }
    public string Operator { get; set; }
    public override string Accept(ISqlVisitor visitor)
    {
        throw new NotImplementedException();
    }
}