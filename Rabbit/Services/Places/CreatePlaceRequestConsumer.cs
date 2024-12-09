using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Places;
using UrFUCoworkingsModels.Responses.Places;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Places
{
    public class CreatePlaceRequestConsumer : IConsumer<CreatePlaceRequest>
    {
        private readonly ServiceManager serviceManager;
        public CreatePlaceRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<CreatePlaceRequest> context)
        {
            CreatePlaceResponse response = new();
            await serviceManager.PlaceService.CreatePlaceAsync(context.Message.ZoneId);
            await context.RespondAsync(response);
        }
    }
}
