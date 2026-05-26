using System.Data;
using Dapper;

namespace Diet.Tracking.API.Infrastructure.Handler;

public class DateTimeTypeHandler : SqlMapper.TypeHandler<DateTime>
{
    public override void SetValue(IDbDataParameter parameter, DateTime value)
    => parameter.Value = value;
    
    public override DateTime Parse(object value)
    {
        return value switch
        {
            DateTime dt => dt,
            DateOnly d => d.ToDateTime(TimeOnly.MinValue),
            _ => Convert.ToDateTime(value)
        };
    }
}