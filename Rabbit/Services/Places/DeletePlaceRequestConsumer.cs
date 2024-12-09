using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Places;
using UrFUCoworkingsModels.Responses.Places;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Places
{
    public class DeletePlaceRequestConsumer : IConsumer<DeletePlaceRequest>
    {
        private readonly ServiceManager serviceManager;
        public DeletePlaceRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<DeletePlaceRequest> context)
        {
            DeletePlaceResponse response = new();
            response.ResponseData = await serviceManager.PlaceService.DeletePlaceAsync(context.Message.PlaceId);
            await context.RespondAsync(response);
        }
    }
}
