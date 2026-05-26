using Diet.Tracking.API.Domain.Enum;

namespace Diet.Tracking.API.Domain.Responses;

public class UserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public BiologicalGenderEnum BiologicalGender { get; set; }
    public double CurrentWeight { get; set; }
    public double GoalWeight { get; set; }
    public double Height { get; set; }
    public BodyMassIndexEnum BMI { get; init;  }
    public WorkoutFrequencyEnum WorkoutFrequency { get; set; }
    public GoalsEnum PersonalGoal { get; set; }
}