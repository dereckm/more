using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlSelectStatement : SqlNode
{
    public List<SqlExpression> Columns { get; set; } = new();
    public SqlExpression FromClause { get; set; }
    public SqlExpression WhereClause { get; set; }
    public SqlSelectModifier Modifier { get; set; }
    public int? TopCount { get; set; }
    // Additional clauses and properties specific to SELECT statements
    public List<SqlJoinClause> JoinClauses { get; set; } = new();
    
    public override string Accept(ISqlVisitor visitor)
    {
        return visitor.Visit(this);
    }
}