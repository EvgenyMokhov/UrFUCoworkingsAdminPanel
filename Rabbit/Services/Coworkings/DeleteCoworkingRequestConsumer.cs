using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class DeleteCoworkingRequestConsumer : IConsumer<DeleteCoworkingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public DeleteCoworkingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<DeleteCoworkingRequest> context)
        {
            //await serviceManager.Coworkings.DeleteCoworkingAsync(context.Message.CoworkingId);
            await publishEndpoint.Publish(new DeleteCoworkingResponse() { Id = context.Message.Id});
        }
    }
}
