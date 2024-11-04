using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Zones;
using UrFUCoworkingsAdminPanel.Models.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class GetZonesRequestConsumer : IConsumer<GetZonesRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public GetZonesRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<GetZonesRequest> context)
        {
            GetZonesResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.ZoneService.GetZonesAsync(context.Message.CoworkingId);
            await publishEndpoint.Publish(response);
        }
    }
}
