using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Coworkings;
using UrFUCoworkingsModels.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class TryUpdateCoworkingRequestConsumer : IConsumer<TryUpdateCoworkingRequest>
    {
        private readonly ServiceManager serviceManager;
        public TryUpdateCoworkingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<TryUpdateCoworkingRequest> context)
        {
            TryUpdateCoworkingResponse response = new();
            response.ResponseData = await serviceManager.CoworkingService.TryUpdateCoworkingAsync(context.Message.RequestData);
            await context.RespondAsync(response);
        }
    }
}
