using System.ComponentModel;

namespace Diet.Tracking.API.Domain.Enum;

public enum BodyMassIndexEnum
{
    [Description("Underweight")]
    Underweight,
    
    [Description("Normal weight")]
    NormalWeight,
    
    [Description("Overweight")]
    Overweight,
    
    [Description("Obesity")]
    Obesity,
}