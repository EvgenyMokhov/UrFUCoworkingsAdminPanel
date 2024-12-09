using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Places;
using UrFUCoworkingsModels.Responses.Places;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Places
{
    public class TryUpdatePlaceRequestConsumer : IConsumer<TryUpdatePlaceRequest>
    {
        private readonly ServiceManager serviceManager;
        public TryUpdatePlaceRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<TryUpdatePlaceRequest> context)
        {
            TryUpdatePlaceResponse response = new();
            response.ResponseData = await serviceManager.PlaceService.TryUpdatePlaceAsync(context.Message.RequestData);
            await context.RespondAsync(response);
        }
    }
}
