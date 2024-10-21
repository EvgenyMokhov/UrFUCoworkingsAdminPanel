using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Models;


namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkingsController : ControllerBase
    {
        private readonly ServiceManager ServiceManager;
        public CoworkingsController(DataManager dataManager) => ServiceManager = new(dataManager);

        [HttpGet(Name = "GetCoworkings")]
        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            return await ServiceManager.CoworkingService.GetCoworkingsAsync();
        }

        [HttpPost(Name = "CreateCoworking")]
        public async Task CreateCoworkingAsync([FromBody] CoworkingEdit editModel)
        {
            await ServiceManager.CoworkingService.CreateCoworkingAsync(editModel);
        }

        [HttpPut(Name = "UpdateCoworking")]
        public async Task UpdateCoworkingAsync([FromBody] CoworkingEdit editModel)
        {
            
        }

        [HttpGet("{coworkingId}", Name = "GetCoworking")]
        public async Task<CoworkingEdit> GetCoworkingByIdAsync(int id)
        { return await ServiceManager.CoworkingService.GetCoworking(id); }
    }
}
