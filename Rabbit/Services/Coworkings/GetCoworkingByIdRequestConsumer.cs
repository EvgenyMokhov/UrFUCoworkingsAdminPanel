using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class GetCoworkingByIdRequestConsumer : IConsumer<GetCoworkingByIdRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public GetCoworkingByIdRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<GetCoworkingByIdRequest> context)
        {
            GetCoworkingByIdResponse response = new();
            response.Id = context.Message.Id;
            response.ResponseData = await serviceManager.CoworkingService.GetCoworkingAsync(context.Message.CoworkingId);
            await publishEndpoint.Publish(response);
        }
    }
}
