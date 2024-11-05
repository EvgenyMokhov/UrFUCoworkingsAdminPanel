using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Zones;
using UrFUCoworkingsAdminPanel.Models.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class DeleteZoneRequestConsumer : IConsumer<DeleteZoneRequest>
    {
        private readonly ServiceManager serviceManager;
        public DeleteZoneRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<DeleteZoneRequest> context)
        {
            await serviceManager.ZoneService.DeleteZoneAsync(context.Message.ZoneId);
            await context.RespondAsync(new DeleteZoneResponse());
        }
    }
}
