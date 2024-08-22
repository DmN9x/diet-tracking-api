using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Tracking.API.Controllers
{
    [ApiController]
    [Route("diet-tracking")]
    public class DietTrackingController : Controller
    {
        private readonly IDietCreatorService _dietCreatorService;
        public DietTrackingController() { }

        [HttpPost("post-personal-information")]
        [ProducesResponseType(typeof(FullDietModel), 200)]
        public async Task<PersonalInformationModel> PostPersonalData(PersonalInformationModel personalInformation)
        {
            return null;
        }
    }
}