using System.Text.RegularExpressions;
using Diet.Tracking.API.Domain.Enum;
using Diet.Tracking.API.Domain.Exceptions;

namespace Diet.Tracking.API.Domain.Entities;

public class User
{
    public int Id { get; init; }
    public string Email { get; set; }
    public string Password { get; set; }
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
    public DateTime CreatedAt { get; }

    public void Validate()
    {
        ValidateEmail(Email);
        ValidateName(FirstName, LastName);
        
        if (string.IsNullOrEmpty(BirthDate.ToString("yyyy-MM-dd")))
            throw new ValidationException(422, "Birth date is required");
        
        if (!BiologicalGender.Equals(BiologicalGenderEnum.Male) &&
            !BiologicalGender.Equals(BiologicalGenderEnum.Female))
            throw new ValidationException(422, "Biological gender is invalid");
        
        if (CurrentWeight <= 0)
            throw new ValidationException(422, "Current weight is required");
        
        if (!PersonalGoal.Equals(GoalsEnum.FatLoss) &&
            !PersonalGoal.Equals(GoalsEnum.WeightGain) &&
            !PersonalGoal.Equals(GoalsEnum.MuscleGain))
            throw new ValidationException(422, "Personal goal is invalid");
        
        if (GoalWeight <= 0)
            throw new ValidationException(422, "Goal weight is required");
        if (GoalWeight >= CurrentWeight && PersonalGoal.Equals(GoalsEnum.FatLoss))
            throw new ValidationException(422, "Goal weight must be lower than your current weight");
        if (GoalWeight <= CurrentWeight && PersonalGoal.Equals(GoalsEnum.MuscleGain))
            throw new ValidationException(422, "Goal weight must be higher than your current weight");
        
        if (Height <= 0)
            throw new ValidationException(422, "Height is required");
        
        if (!WorkoutFrequency.Equals(WorkoutFrequencyEnum.Never) && !WorkoutFrequency.Equals(WorkoutFrequencyEnum.Somewhat) &&
            !WorkoutFrequency.Equals(WorkoutFrequencyEnum.Often) && !WorkoutFrequency.Equals(WorkoutFrequencyEnum.Daily))
            throw new ValidationException(422, "Workout frequency is invalid");
    }
    
    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ValidationException(422, "Email is required");
        
        var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        
        if (!regex.IsMatch(email))
            throw new ValidationException(422, "Email is invalid");
    }
    
    private static void ValidateName(string firstName, string lastName)
    {
        var nameRegexValidation = new Regex(@"^[a-zA-ZÀ-ÿ]+([ '-][a-zA-ZÀ-ÿ]+)*$");

        if (string.IsNullOrEmpty(firstName))
            throw new ValidationException(422, "First name is required");
        if ((firstName.Length < 2 || firstName.Length > 100) && nameRegexValidation.IsMatch(firstName))
            throw new ValidationException(422, "First name is invalid");

        if (string.IsNullOrEmpty(lastName))
            throw new ValidationException(422, "Last name is required");
        if ((lastName.Length < 2 || lastName.Length > 100) && nameRegexValidation.IsMatch(lastName))
            throw new ValidationException(422, "Last name is invalid");
    }
}
