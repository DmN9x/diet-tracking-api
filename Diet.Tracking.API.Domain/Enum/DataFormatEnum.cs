using System.ComponentModel;

namespace Diet.Tracking.API.Domain.Enum;

public enum MetricSystemEnum
{
    [Description("International")]
    International,
    
    [Description("Imperial")]
    Imperial
}