using System.Text;
using More.Sql.Models;

namespace More.Sql.Conversion;

public class SqlToSqlStringVisitor : ISqlVisitor
{
    public string Visit(SqlSelectStatement selectStatement)
    {
        var sqlBuilder = new StringBuilder();

        sqlBuilder.Append("SELECT ");

        if (selectStatement.Modifier == SqlSelectModifier.Distinct)
        {
            sqlBuilder.Append("DISTINCT ");
        }
        else if (selectStatement.Modifier == SqlSelectModifier.Top && selectStatement.TopCount.HasValue)
        {
            sqlBuilder.Append($"TOP {selectStatement.TopCount.Value} ");
        }

        if (selectStatement.Columns.Count > 0)
        {
            sqlBuilder.Append(string.Join(", ", selectStatement.Columns.Select(c => c.Accept(this))));
        }
        else
        {
            sqlBuilder.Append('*');
        }

        sqlBuilder.AppendLine();
        sqlBuilder.Append("FROM ");
        sqlBuilder.Append(selectStatement.FromClause.Accept(this));

        foreach (var joinClause in selectStatement.JoinClauses)
        {
            sqlBuilder.AppendLine();
            sqlBuilder.Append(joinClause.Accept(this));
        }

        if (selectStatement.WhereClause != null)
        {
            sqlBuilder.AppendLine();
            sqlBuilder.Append("WHERE ");
            sqlBuilder.Append(selectStatement.WhereClause.Accept(this));
        }

        return sqlBuilder.ToString();
    }

    public string Visit(SqlIdentifier identifier)
    {
        return identifier.Name;
    }

    public string Visit(SqlJoinClause joinClause)
    {
        var sqlBuilder = new StringBuilder();

        // Join type
        switch (joinClause.JoinType)
        {
            case SqlJoinType.Inner:
                sqlBuilder.Append("INNER JOIN ");
                break;
            case SqlJoinType.Left:
                sqlBuilder.Append("LEFT JOIN ");
                break;
            case SqlJoinType.Right:
                sqlBuilder.Append("RIGHT JOIN ");
                break;
            case SqlJoinType.FullOuter:
                sqlBuilder.Append("FULL OUTER JOIN ");
                break;
            case SqlJoinType.Cross:
                sqlBuilder.Append("CROSS JOIN ");
                break;
        }

        // Right table and join condition
        sqlBuilder.Append(joinClause.RightTable.Accept(this));
        sqlBuilder.AppendLine();
        sqlBuilder.Append("ON ");
        sqlBuilder.Append(joinClause.Condition.Accept(this));

        return sqlBuilder.ToString();
    }
    
    public string Visit(SqlBinaryExpression binaryExpression)
    {
        var sqlBuilder = new StringBuilder();

        sqlBuilder.Append("(");
        sqlBuilder.Append(binaryExpression.Left.Accept(this));

        switch (binaryExpression.Operator)
        {
            case SqlBinaryOperator.Add:
                sqlBuilder.Append(" + ");
                break;
            case SqlBinaryOperator.Subtract:
                sqlBuilder.Append(" - ");
                break;
            case SqlBinaryOperator.Multiply:
                sqlBuilder.Append(" * ");
                break;
            case SqlBinaryOperator.Divide:
                sqlBuilder.Append(" / ");
                break;
            case SqlBinaryOperator.Modulo:
                sqlBuilder.Append(" % ");
                break;
            case SqlBinaryOperator.Equal:
                sqlBuilder.Append(" = ");
                break;
            case SqlBinaryOperator.NotEqual:
                sqlBuilder.Append(" <> ");
                break;
            case SqlBinaryOperator.GreaterThan:
                sqlBuilder.Append(" > ");
                break;
            case SqlBinaryOperator.GreaterThanOrEqual:
                sqlBuilder.Append(" >= ");
                break;
            case SqlBinaryOperator.LessThan:
                sqlBuilder.Append(" < ");
                break;
            case SqlBinaryOperator.LessThanOrEqual:
                sqlBuilder.Append(" <= ");
                break;
            case SqlBinaryOperator.And:
                sqlBuilder.Append(" AND ");
                break;
            case SqlBinaryOperator.Or:
                sqlBuilder.Append(" OR ");
                break;
            // Add more cases for other binary operators as needed
            default:
                throw new NotSupportedException($"Unsupported binary operator: {binaryExpression.Operator}");
        }

        sqlBuilder.Append(binaryExpression.Right.Accept(this));
        sqlBuilder.Append(")");

        return sqlBuilder.ToString();
    }
}
