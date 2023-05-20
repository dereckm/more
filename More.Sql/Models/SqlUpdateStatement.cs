using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlUpdateStatement : SqlNode
{
    public string TableName { get; set; }
    public List<SqlIdentifier> Columns { get; set; }
    public List<SqlExpression> Values { get; set; }
    public SqlExpression WhereClause { get; set; }
    // Additional clauses and properties specific to UPDATE statements
    public override string Accept(ISqlVisitor visitor)
    {
        throw new NotImplementedException();
    }
}