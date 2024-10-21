using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.Models;


namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkingsController : ControllerBase
    {
        [HttpGet(Name = "GetCoworkings")]
        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            return new();
        }

        [HttpPost(Name = "CreateCoworking")]
        public async Task CreateCoworkingAsync(CoworkingEdit editModel)
        {

        }

        [HttpPut(Name = "UpdateCoworking")]
        public async Task UpdateCoworkingAsync([FromBody] CoworkingEdit editModel)
        {
            
        }

        [HttpGet("{coworkingId}", Name = "GetCoworking")]
        public async Task<CoworkingView> GetCoworkingByIdAsync(int id)
        { return new(); }
    }
}
