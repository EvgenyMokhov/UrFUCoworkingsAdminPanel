using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class SaveSettingAnywayRequestConsumer : IConsumer<SaveSettingAnywayRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public SaveSettingAnywayRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<SaveSettingAnywayRequest> context)
        {
            SaveSettingAnywayResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CSService.CSSaveAsync(context.Message.CoworkingId, context.Message.SettingData);
            await publishEndpoint.Publish(response);
        }
    }
}
