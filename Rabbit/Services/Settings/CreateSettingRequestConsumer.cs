using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Settings;
using UrFUCoworkingsModels.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class CreateSettingRequestConsumer : IConsumer<CreateSettingRequest>
    {
        private readonly ServiceManager serviceManager;
        public CreateSettingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        
        public async Task Consume(ConsumeContext<CreateSettingRequest> context)
        {
            await serviceManager.CSService.CreateSettingAsync(context.Message.CoworkingId);
            await context.RespondAsync(new CreateSettingResponse());
        }
    }
}
