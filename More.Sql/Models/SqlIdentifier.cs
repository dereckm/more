using More.Sql.Conversion;

namespace More.Sql.Models;

public class SqlIdentifier : SqlExpression
{
    public SqlIdentifier() { }
    public SqlIdentifier(string name)
    {
        Name = name;
    }
    
    public string Name { get; set; }
    
    public override string Accept(ISqlVisitor visitor)
    {
        return visitor.Visit(this);
    }
}