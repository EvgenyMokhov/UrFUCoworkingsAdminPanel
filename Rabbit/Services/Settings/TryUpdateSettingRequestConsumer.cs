using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Settings;
using UrFUCoworkingsModels.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class TryUpdateSettingRequestConsumer : IConsumer<TryUpdateSettingRequest>
    {
        private readonly ServiceManager serviceManager;
        public TryUpdateSettingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<TryUpdateSettingRequest> context)
        {
            TryUpdateSettingResponse response = new();
            response.ResponseData = await serviceManager.CSService.TryCSSaveAsync(context.Message.SettingData);
            await context.RespondAsync(response);
        }
    }
}
