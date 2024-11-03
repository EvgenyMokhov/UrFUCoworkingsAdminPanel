using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class TrySaveSettingRequestConsumer : IConsumer<TrySaveSettingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public TrySaveSettingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<TrySaveSettingRequest> context)
        {
            TrySaveSettingResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CSService.TryCSSaveAsync(context.Message.CoworkingId, context.Message.SettingData);
            await publishEndpoint.Publish(response);
        }
    }
}
