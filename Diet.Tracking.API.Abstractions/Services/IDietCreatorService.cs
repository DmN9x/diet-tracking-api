using Diet.Tracking.API.Domain.Models;

namespace Diet.Tracking.API.Abstractions.Services
{
    public interface IDietCreatorService
    {
        public Task<FullDietModel> CreateDietAsync(PersonalInformationModel personalInformation);
    }
}