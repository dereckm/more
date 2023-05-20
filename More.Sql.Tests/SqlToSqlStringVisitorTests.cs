using System;
using System.Collections.Generic;
using More.Sql.Conversion;
using More.Sql.Models;
using FluentAssertions;
using NUnit.Framework;

namespace More.Sql.Tests;

public class SqlToSqlStringVisitorTests
{
    [Test]
    public void Visit_SelectStatementWithAllColumns_ReturnsCorrectSql()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var selectStatement = new SqlSelectStatement
        {
            Columns = new List<SqlExpression>
            {
                new SqlIdentifier { Name = "Column1" },
                new SqlIdentifier { Name = "Column2" },
                new SqlIdentifier { Name = "Column3" }
            },
            FromClause = new SqlIdentifier { Name = "Table1" }
        };
        var expectedSql = "SELECT Column1, Column2, Column3" + System.Environment.NewLine +
                          "FROM Table1";

        // Act
        var actualSql = visitor.Visit(selectStatement);

        // Assert
        actualSql.Should().Be(expectedSql);
    }

    [Test]
    public void Visit_SelectStatementWithDistinctModifier_ReturnsCorrectSql()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var selectStatement = new SqlSelectStatement
        {
            Modifier = SqlSelectModifier.Distinct,
            Columns = new List<SqlExpression>
            {
                new SqlIdentifier { Name = "Column1" },
                new SqlIdentifier { Name = "Column2" }
            },
            FromClause = new SqlIdentifier { Name = "Table1" }
        };
        var expectedSql = "SELECT DISTINCT Column1, Column2" + System.Environment.NewLine +
                          "FROM Table1";

        // Act
        var actualSql = visitor.Visit(selectStatement);

        // Assert
        actualSql.Should().Be(expectedSql);
    }

    [Test]
    public void Visit_SelectStatementWithTopModifier_ReturnsCorrectSql()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var selectStatement = new SqlSelectStatement
        {
            Modifier = SqlSelectModifier.Top,
            TopCount = 10,
            Columns = new List<SqlExpression>
            {
                new SqlIdentifier { Name = "Column1" },
                new SqlIdentifier { Name = "Column2" }
            },
            FromClause = new SqlIdentifier { Name = "Table1" }
        };
        var expectedSql = "SELECT TOP 10 Column1, Column2" + System.Environment.NewLine +
                          "FROM Table1";

        // Act
        var actualSql = visitor.Visit(selectStatement);

        // Assert
        actualSql.Should().Be(expectedSql);
    }

    [Test]
    public void Visit_SelectStatementWithWhereClause_ReturnsCorrectSql()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var selectStatement = new SqlSelectStatement
        {
            Columns = new List<SqlExpression>
            {
                new SqlIdentifier { Name = "Column1" },
                new SqlIdentifier { Name = "Column2" }
            },
            FromClause = new SqlIdentifier { Name = "Table1" },
            WhereClause = new SqlIdentifier { Name = "Column1 = 10" }
        };
        var expectedSql = "SELECT Column1, Column2" + System.Environment.NewLine +
                          "FROM Table1" + System.Environment.NewLine +
                          "WHERE Column1 = 10";

        // Act
        var actualSql = visitor.Visit(selectStatement);

        // Assert
        actualSql.Should().Be(expectedSql);
    }

    [Test]
    public void Visit_Identifier_ReturnsCorrectSql()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var identifier = new SqlIdentifier { Name = "Table1" };
        var expectedSql = "Table1";

        // Act
        var actualSql = visitor.Visit(identifier);

        // Assert
        actualSql.Should().Be(expectedSql);
    }
    
        [Test]
    public void Visit_WithInnerJoin_ReturnsCorrectSqlString()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var joinClause = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Customers"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.CustomerId"),
            new SqlIdentifier("Customers.CustomerId"),
            SqlBinaryOperator.Equal), SqlJoinType.Inner);

        var selectStatement = new SqlSelectStatement
        {
            FromClause = new SqlIdentifier {Name = "Orders"},
        };
        selectStatement.JoinClauses.Add(joinClause);

        // Act
        var sqlString = visitor.Visit(selectStatement);

        // Assert
        sqlString.Should().Be("SELECT *" + Environment.NewLine +
                              "FROM Orders" + Environment.NewLine +
                              "INNER JOIN Customers" + Environment.NewLine +
                              "ON (Orders.CustomerId = Customers.CustomerId)");
    }

    [Test]
    public void Visit_WithLeftJoin_ReturnsCorrectSqlString()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var joinClause = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Customers"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.CustomerId"),
            new SqlIdentifier("Customers.CustomerId"),
            SqlBinaryOperator.Equal), SqlJoinType.Left);

        var selectStatement = new SqlSelectStatement
        {
            FromClause = new SqlIdentifier {Name = "Orders"},
        };
        selectStatement.JoinClauses.Add(joinClause);

        // Act
        var sqlString = visitor.Visit(selectStatement);

        // Assert
        sqlString.Should().Be("SELECT *" + Environment.NewLine +
                              "FROM Orders" + Environment.NewLine +
                              "LEFT JOIN Customers" + Environment.NewLine +
                              "ON (Orders.CustomerId = Customers.CustomerId)");
    }

    [Test]
    public void Visit_WithRightJoin_ReturnsCorrectSqlString()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var joinClause = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Customers"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.CustomerId"),
            new SqlIdentifier("Customers.CustomerId"),
            SqlBinaryOperator.Equal), SqlJoinType.Right);

        var selectStatement = new SqlSelectStatement
        {
            FromClause = new SqlIdentifier {Name = "Orders"},
        };
        selectStatement.JoinClauses.Add(joinClause);

        // Act
        var sqlString = visitor.Visit(selectStatement);

        // Assert
        sqlString.Should().Be("SELECT *" + Environment.NewLine +
                              "FROM Orders" + Environment.NewLine +
                              "RIGHT JOIN Customers" + Environment.NewLine +
                              "ON (Orders.CustomerId = Customers.CustomerId)");
    }

    [Test]
    public void Visit_WithFullOuterJoin_ReturnsCorrectSqlString()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var joinClause = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Customers"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.CustomerId"),
            new SqlIdentifier("Customers.CustomerId"),
            SqlBinaryOperator.Equal), SqlJoinType.FullOuter);

        var selectStatement = new SqlSelectStatement
        {
            FromClause = new SqlIdentifier { Name = "Orders" },
        };
        selectStatement.JoinClauses.Add(joinClause);

        // Act
        var sqlString = visitor.Visit(selectStatement);

        // Assert
        sqlString.Should().Be("SELECT *" + Environment.NewLine +
                              "FROM Orders" + Environment.NewLine +
                              "FULL OUTER JOIN Customers" + Environment.NewLine +
                              "ON (Orders.CustomerId = Customers.CustomerId)");
    }

    [Test]
    public void Visit_WithMultipleJoinClauses_ReturnsCorrectSqlString()
    {
        // Arrange
        var visitor = new SqlToSqlStringVisitor();
        var joinClause1 = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Customers"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.CustomerId"),
            new SqlIdentifier("Customers.CustomerId"),
            SqlBinaryOperator.Equal), SqlJoinType.Inner);

        var joinClause2 = new SqlJoinClause(new SqlIdentifier("Orders"), new SqlIdentifier("Products"), new SqlBinaryExpression(
            new SqlIdentifier("Orders.ProductId"),
            new SqlIdentifier("Products.ProductId"),
            SqlBinaryOperator.Equal), SqlJoinType.Left);

        var selectStatement = new SqlSelectStatement
        {
            FromClause = new SqlIdentifier { Name = "Orders" },
        };
        selectStatement.JoinClauses.Add(joinClause1);
        selectStatement.JoinClauses.Add(joinClause2);

        // Act
        var sqlString = visitor.Visit(selectStatement);

        // Assert
        sqlString.Should().Be("SELECT *" + Environment.NewLine +
                              "FROM Orders" + Environment.NewLine +
                              "INNER JOIN Customers" + Environment.NewLine +
                              "ON (Orders.CustomerId = Customers.CustomerId)" + Environment.NewLine +
                              "LEFT JOIN Products" + Environment.NewLine +
                              "ON (Orders.ProductId = Products.ProductId)");
    }
}
