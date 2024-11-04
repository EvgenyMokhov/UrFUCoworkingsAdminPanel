using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class UpdateSettingAnywayRequestConsumer : IConsumer<UpdateSettingAnywayRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public UpdateSettingAnywayRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<UpdateSettingAnywayRequest> context)
        {
            UpdateSettingAnywayResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CSService.CSSaveAsync(context.Message.CoworkingId, context.Message.SettingData);
            await publishEndpoint.Publish(response);
        }
    }
}
