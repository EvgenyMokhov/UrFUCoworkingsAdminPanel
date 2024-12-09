using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Places;
using UrFUCoworkingsModels.Responses.Places;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Places
{
    public class UpdatePlaceRequestConsumer : IConsumer<UpdatePlaceRequest>
    {
        private readonly ServiceManager serviceManager;
        public UpdatePlaceRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<UpdatePlaceRequest> context)
        {
            UpdatePlaceResponse response = new();
            response.ResponseData = await serviceManager.PlaceService.UpdatePlaceAsync(context.Message.RequestData);
            await context.RespondAsync(response);
        }
    }
}
