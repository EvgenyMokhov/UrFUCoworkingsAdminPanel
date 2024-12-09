using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Places;
using UrFUCoworkingsModels.Responses.Places;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Places
{
    public class GetPlacesRequestConsumer : IConsumer<GetPlacesRequest>
    {
        private readonly ServiceManager serviceManager;
        public GetPlacesRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<GetPlacesRequest> context)
        {
            GetPlacesResponse response = new();
            response.ResponseData = await serviceManager.PlaceService.GetPlacesAsync(context.Message.ZoneId);
            await context.RespondAsync(response);
        }
    }
}
