﻿using Microsoft.AspNetCore.Mvc;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.DTOs;


namespace UrFUCoworkingsAdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkingsController : ControllerBase
    {
        private readonly ServiceManager ServiceManager;
        public CoworkingsController(IServiceProvider provider) => ServiceManager = new(provider);

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
            await ServiceManager.CoworkingService.UpdateCoworkingAsync(editModel);
        }

        [HttpGet("{coworkingId}", Name = "GetCoworking")]
        public async Task<CoworkingEdit> GetCoworkingByIdAsync(Guid coworkingId)
        { 
            return await ServiceManager.CoworkingService.GetCoworkingAsync(coworkingId); 
        }

        [HttpDelete(Name = "DeleteCoworking")]
        public async Task DeleteCoworkingAsync([FromQuery] Guid coworkingId)
        {
            
        }
    }
}
