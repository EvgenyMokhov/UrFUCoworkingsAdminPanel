using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class DeleteSettingRequestConsumer : IConsumer<DeleteSettingRequest>
    {
        private readonly ServiceManager serviceManager;
        public DeleteSettingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<DeleteSettingRequest> context)
        {
            await serviceManager.CSService.DeleteSettingAsync(context.Message.SettingId);
            await context.RespondAsync(new DeleteSettingResponse());
        }
    }
}
