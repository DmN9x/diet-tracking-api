using System.ComponentModel;

namespace Diet.Tracking.API.Domain.Enum
{
    public enum WorkoutFrequencyEnum
    {
        [Description("Never")]
        Never = 0,

        [Description("Once or twice per week")]
        Somewhat = 1,

        [Description("Three to four times a week")]
        Often = 2,

        [Description("Every day")]
        Daily = 3
    }
}