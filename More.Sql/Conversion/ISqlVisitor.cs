using More.Sql.Models;

namespace More.Sql.Conversion;

public interface ISqlVisitor
{
    string Visit(SqlSelectStatement selectStatement);
    string Visit(SqlIdentifier identifier);

    string Visit(SqlJoinClause joinClause);

    string Visit(SqlBinaryExpression binaryExpression);
    // Add other Visit methods for different SQL nodes here
}