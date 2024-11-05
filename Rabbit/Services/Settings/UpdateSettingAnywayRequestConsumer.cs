using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class UpdateSettingAnywayRequestConsumer : IConsumer<UpdateSettingAnywayRequest>
    {
        private readonly ServiceManager serviceManager;
        public UpdateSettingAnywayRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<UpdateSettingAnywayRequest> context)
        {
            UpdateSettingAnywayResponse response = new();
            response.ResponseData = await serviceManager.CSService.CSSaveAsync(context.Message.CoworkingId, context.Message.SettingData);
            await context.RespondAsync(response);
        }
    }
}
