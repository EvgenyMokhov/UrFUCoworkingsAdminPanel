using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Settings;
using UrFUCoworkingsModels.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class UpdateSettingAnywayRequestConsumer : IConsumer<UpdateSettingAnywayRequest>
    {
        private readonly ServiceManager serviceManager;
        public UpdateSettingAnywayRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<UpdateSettingAnywayRequest> context)
        {
            UpdateSettingAnywayResponse response = new();
            response.ResponseData = await serviceManager.CSService.CSSaveAsync(context.Message.SettingData);
            await context.RespondAsync(response);
        }
    }
}
