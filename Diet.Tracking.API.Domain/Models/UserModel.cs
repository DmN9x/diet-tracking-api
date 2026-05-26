using System.Text.RegularExpressions;
using Diet.Tracking.API.Domain.Enum;
using Diet.Tracking.API.Enum;
using Diet.Tracking.API.Domain.Exceptions;

namespace Diet.Tracking.API.Domain.Models
{
    public class UserModel
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public BiologicalGenderEnum BiologicalGender { get; set; }
        public double CurrentWeight { get; set; }
        public double GoalWeight { get; set; }
        public double Height { get; set; }
        public WorkoutFrequencyEnum WorkoutFrequency { get; set; }
        public GoalsEnum PersonalGoal { get; set; }

        public void Validate()
        {
            var nameRegexValidation = new Regex(@"^[a-zA-ZÀ-ÿ]+([ '-][a-zA-ZÀ-ÿ]+)*$");
            
            if (string.IsNullOrEmpty(FirstName))
                throw new ValidationException(422, "First name is required");
            if ((FirstName.Length < 2 || FirstName.Length > 100) && nameRegexValidation.IsMatch(FirstName))
                throw new ValidationException(422, "First name is invalid");
            
            if (string.IsNullOrEmpty(LastName))
                throw new ValidationException(422, "First name is required");
            if ((LastName.Length < 2 || LastName.Length > 100) && nameRegexValidation.IsMatch(LastName))
                throw new ValidationException(422, "First name is invalid");
            
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
    }
}