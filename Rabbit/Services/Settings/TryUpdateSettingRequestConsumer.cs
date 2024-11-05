using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class TryUpdateSettingRequestConsumer : IConsumer<TryUpdateSettingRequest>
    {
        private readonly ServiceManager serviceManager;
        public TryUpdateSettingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<TryUpdateSettingRequest> context)
        {
            TryUpdateSettingResponse response = new();
            response.ResponseData = await serviceManager.CSService.TryCSSaveAsync(context.Message.CoworkingId, context.Message.SettingData);
            await context.RespondAsync(response);
        }
    }
}
