using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Zones;
using UrFUCoworkingsModels.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class TryUpdateZoneRequestConsumer : IConsumer<TryUpdateZoneRequest>
    {
        private readonly ServiceManager serviceManager;
        public TryUpdateZoneRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<TryUpdateZoneRequest> context)
        {
            TryUpdateZoneResponse response = new();
            response.ResponseData = await serviceManager.ZoneService.TryUpdateZoneAsync(context.Message.RequestData);
            await context.RespondAsync(response);
        }
    }
}
