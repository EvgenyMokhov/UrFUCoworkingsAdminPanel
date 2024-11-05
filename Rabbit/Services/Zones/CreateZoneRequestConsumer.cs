using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Zones;
using UrFUCoworkingsAdminPanel.Models.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class CreateZoneRequestConsumer : IConsumer<CreateZoneRequest>
    {
        private readonly ServiceManager serviceManager;
        public CreateZoneRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<CreateZoneRequest> context)
        {
            await serviceManager.ZoneService.CreateZoneAsync(context.Message.CoworkingId);
            await context.RespondAsync(new CreateZoneResponse());
        }
    }
}
