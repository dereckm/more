using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlLiteral : SqlExpression
{
    public object Value { get; set; }
    public override string Accept(ISqlVisitor visitor)
    {
        throw new NotImplementedException();
    }
}