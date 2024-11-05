using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Settings;
using UrFUCoworkingsAdminPanel.Models.Responses.Settings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Settings
{
    public class GetSettingsRequestConsumer : IConsumer<GetSettingsRequest>
    {
        private readonly ServiceManager serviceManager;
        public GetSettingsRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        

        public async Task Consume(ConsumeContext<GetSettingsRequest> context)
        {
            GetSettingsResponse response = new();
            response.ResponseData = await serviceManager.CSService.GetSettingsAsync(context.Message.CoworkingId);
            await context.RespondAsync(response);
        }
    }
}
