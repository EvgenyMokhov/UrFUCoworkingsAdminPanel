using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class UpdateCoworkingRequestConsumer : IConsumer<UpdateCoworkingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public UpdateCoworkingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }

        public async Task Consume(ConsumeContext<UpdateCoworkingRequest> context)
        {
            await serviceManager.CoworkingService.UpdateCoworkingAsync(context.Message.RequestData);
            await publishEndpoint.Publish(new UpdateCoworkingResponse() { Id = context.Message.Id });
        }
    }
}
