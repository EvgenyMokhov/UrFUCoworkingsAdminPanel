using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Zones;
using UrFUCoworkingsModels.Responses.Zones;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Zones
{
    public class UpdateZoneRequestConsumer : IConsumer<UpdateZoneRequest>
    {
        private readonly ServiceManager serviceManager;
        public UpdateZoneRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        
        public async Task Consume(ConsumeContext<UpdateZoneRequest> context)
        {
            await serviceManager.ZoneService.UpdateZoneAsync(context.Message.RequestData);
            await context.RespondAsync(new UpdateZoneResponse());
        }
    }
}
