using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlJoinClause : SqlNode
{
    public SqlJoinClause(SqlIdentifier leftTable, SqlIdentifier rightTable, SqlBinaryExpression joinCondition, SqlJoinType joinType)
    {
        LeftTable = leftTable;
        RightTable = rightTable;
        Condition = joinCondition;
        JoinType = joinType;
    }
    
    public SqlJoinType JoinType { get; set; }
    public SqlIdentifier LeftTable { get; set; }
    public SqlIdentifier RightTable { get; set; }
    public SqlBinaryExpression? Condition { get; set; }
    public override string Accept(ISqlVisitor visitor)
    {
        return visitor.Visit(this);
    }
}