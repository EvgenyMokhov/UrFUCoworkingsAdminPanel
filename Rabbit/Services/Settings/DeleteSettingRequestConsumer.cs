using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class DeleteSettingRequestConsumer : IConsumer<DeleteSettingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public DeleteSettingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<DeleteSettingRequest> context)
        {
            await serviceManager.CSService.DeleteSettingAsync(context.Message.SettingId);
            await publishEndpoint.Publish(new DeleteSettingResponse() { Id=context.Message.Id});
        }
    }
}
