using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.DTOs;
using UrFUCoworkingsModels.Requests.Coworkings;
using UrFUCoworkingsModels.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class CreateCoworkingRequestConsumer : IConsumer<CreateCoworkingRequest>
    {
        private readonly ServiceManager serviceManager;
        public CreateCoworkingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<CreateCoworkingRequest> context)
        {
            CoworkingEdit coworking = new();
            coworking.Name = "Coworking";
            coworking.Settings = new();
            coworking.Zones = new();
            CreateCoworkingResponse response = new();
            await serviceManager.CoworkingService.CreateCoworkingAsync(coworking);
            await context.RespondAsync(response);
        }
    }
}
