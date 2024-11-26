using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Zones;
using UrFUCoworkingsModels.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class GetZonesRequestConsumer : IConsumer<GetZonesRequest>
    {
        private readonly ServiceManager serviceManager;
        public GetZonesRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        
        public async Task Consume(ConsumeContext<GetZonesRequest> context)
        {
            GetZonesResponse response = new();
            response.ResponseData = await serviceManager.ZoneService.GetZonesAsync(context.Message.CoworkingId);
            await context.RespondAsync(response);
        }
    }
}
