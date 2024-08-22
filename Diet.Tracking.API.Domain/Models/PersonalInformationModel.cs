using Diet.Tracking.API.Domain.Enum;
using Diet.Tracking.API.Enum;

namespace Diet.Tracking.API.Domain.Models
{
    public class PersonalInformationModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        public float CurrentWheight { get; set; }
        public float GoalWheight { get; set; }
        public float Height { get; set; }
        public bool ExperienceWorkingOut { get; set; }
        public WorkingOutPeriodModel MonthsWorkingOut { get; set; }
        public GoalsEnum PersonalGoal { get; set; }
    }
}