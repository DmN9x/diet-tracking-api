using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Models;

namespace Diet.Tracking.API.Services.DietTracking
{
    public class DietCreatorService : IDietCreatorService
    {
        public async Task<FullDietModel> CreateDietAsync(PersonalInformationModel personalInformation)
        {
            var diet = new FullDietModel()
            {

            };

            return new FullDietModel();
        }
    }
}