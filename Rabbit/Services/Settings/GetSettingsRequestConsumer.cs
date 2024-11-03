using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class GetSettingsRequestConsumer : IConsumer<GetSettingsRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public GetSettingsRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<GetSettingsRequest> context)
        {
            GetSettingsResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CSService.GetSettingsAsync(context.Message.CoworkingId);
            await publishEndpoint.Publish(response);
        }
    }
}
