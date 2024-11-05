using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class GetCoworkingsRequestConsumer : IConsumer<GetCoworkingsRequest>
    {
        private readonly ServiceManager serviceManager;
        public GetCoworkingsRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<GetCoworkingsRequest> context)
        {
            GetCoworkingsResponse response = new();
            response.ResponseData = await serviceManager.CoworkingService.GetCoworkingsAsync();
            await context.RespondAsync(response);
        }
    }
}
