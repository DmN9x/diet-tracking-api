using System.ComponentModel;

namespace Diet.Tracking.API.Domain.Enum
{
    public enum GoalsEnum
    {
        [Description("Fat loss")]
        FatLoss,

        [Description("Weight gain")]
        WeightGain,

        [Description("Muscle gain")]
        MuscleGain
    }
}