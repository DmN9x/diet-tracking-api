using System.ComponentModel;

namespace Diet.Tracking.API.Domain.Enum
{
    public enum PeriodOfTimeEnum
    {
        [Description("Days")]
        Days,

        [Description("Months")]
        Months,

        [Description("Years")]
        Years
    }
}
