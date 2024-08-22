using Diet.Tracking.API.Domain.Enum;
namespace Diet.Tracking.API.Domain
{
    public class WorkingOutPeriodModel
    {
        private float _quantityFormated;
        public float QuantityInformed
        {
            get => _quantityFormated;
            set
            {
                if (PeriodOfTime == PeriodOfTimeEnum.Days)
                {
                    _quantityFormated = QuantityInformed / 30f;
                }
                else if (PeriodOfTime == PeriodOfTimeEnum.Years)
                {
                    _quantityFormated = QuantityInformed / 12f;
                }
            }
        }
        public PeriodOfTimeEnum PeriodOfTime { get; set; }
    }
}