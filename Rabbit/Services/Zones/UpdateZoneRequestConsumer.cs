using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Zones;
using UrFUCoworkingsAdminPanel.Models.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class UpdateZoneRequestConsumer : IConsumer<UpdateZoneRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public UpdateZoneRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<UpdateZoneRequest> context)
        {
            await serviceManager.ZoneService.UpdateZoneAsync(context.Message.CoworkingId, context.Message.RequestData);
            await publishEndpoint.Publish(new UpdateZoneResponse() { Id = context.Message.Id });
        }
    }
}
