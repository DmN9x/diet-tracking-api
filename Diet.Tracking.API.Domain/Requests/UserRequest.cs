using System.Text.RegularExpressions;
using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Enum;
using Diet.Tracking.API.Domain.Exceptions;

namespace Diet.Tracking.API.Domain.Requests;

public class UserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public BiologicalGenderEnum BiologicalGender { get; set; }
    public double CurrentWeight { get; set; }
    public double GoalWeight { get; set; }
    public double Height { get; set; }
    public WorkoutFrequencyEnum WorkoutFrequency { get; set; }
    public GoalsEnum PersonalGoal { get; set; }
    public MetricSystemEnum MetricSystem { get; set; }

    public User CreateByRequest()
    {
        return new User
        {
            Email = Email,
            Password = EncryptPassword(Password),
            FirstName = FirstName,
            LastName = LastName,
            BirthDate = BirthDate,
            BiologicalGender = BiologicalGender,
            CurrentWeight = CurrentWeight,
            GoalWeight = GoalWeight,
            Height = Height,
            BMI = CalculateBMI(CurrentWeight, Height, MetricSystem),
            WorkoutFrequency = WorkoutFrequency,
            PersonalGoal = PersonalGoal
        };
    }
    
    private static BodyMassIndexEnum CalculateBMI(double height, double weight, MetricSystemEnum metricSystem)
    {
        if (metricSystem.Equals(MetricSystemEnum.Imperial))
        {
            weight = weight / 2.2;

            var feet = double.Parse(height.ToString().Split(".")[0]) * 30.48F;
            var inches = double.Parse(height.ToString().Split(".")[1]) * 2.54F;
            height = feet + inches;
        }

        var bmi = weight * (height * 2);
        
        return bmi switch
        {
            < 18.5f => BodyMassIndexEnum.Underweight,
            >= 18.5f and <= 24.9f => BodyMassIndexEnum.NormalWeight,
            >= 25f and <= 29.9f => BodyMassIndexEnum.Overweight,
            >= 30f => BodyMassIndexEnum.Obesity,
            _ => BodyMassIndexEnum.Underweight
        };
    }

    private static string EncryptPassword(string password)
    {
        ValidatePassword(password);
        return BCrypt.Net.BCrypt.HashPassword(password); 
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ValidationException(422, "Password is required");
        
        var regex = new Regex(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{8,}$");
        
        if (!regex.IsMatch(password))
            throw new ValidationException(422, "Password is invalid");
    }
}