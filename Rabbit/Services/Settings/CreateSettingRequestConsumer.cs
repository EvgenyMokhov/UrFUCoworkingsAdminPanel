using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class CreateSettingRequestConsumer : IConsumer<CreateSettingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public CreateSettingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<CreateSettingRequest> context)
        {
            await serviceManager.CSService.CreateSettingAsync(context.Message.CoworkingId);
            await publishEndpoint.Publish(new CreateSettingResponse() { Id = context.Message.Id });
        }
    }
}
