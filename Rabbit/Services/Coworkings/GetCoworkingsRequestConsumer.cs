using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class GetCoworkingsRequestConsumer : IConsumer<GetCoworkingsRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public GetCoworkingsRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<GetCoworkingsRequest> context)
        {
            GetCoworkingsResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CoworkingService.GetCoworkingsAsync();
            await publishEndpoint.Publish(response);
        }
    }
}
