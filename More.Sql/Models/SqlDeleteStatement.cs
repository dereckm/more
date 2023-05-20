using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlDeleteStatement : SqlNode
{
    public string TableName { get; set; }
    public SqlExpression WhereClause { get; set; }
    // Additional clauses and properties specific to DELETE statements
    public override string Accept(ISqlVisitor visitor)
    {
        throw new NotImplementedException();
    }
}