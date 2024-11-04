using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Zones;
using UrFUCoworkingsAdminPanel.Models.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class DeleteZoneRequestConsumer : IConsumer<DeleteZoneRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public DeleteZoneRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<DeleteZoneRequest> context)
        {
            await serviceManager.ZoneService.DeleteZoneAsync(context.Message.ZoneId);
            await publishEndpoint.Publish(new DeleteZoneResponse() { Id = context.Message.Id });
        }
    }
}
