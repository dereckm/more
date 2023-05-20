using More.Sql.Conversion;

namespace More.Sql.Models;

public abstract class SqlNode
{
    // Common properties and methods for all SQL nodes
    
    public abstract string Accept(ISqlVisitor visitor);
}