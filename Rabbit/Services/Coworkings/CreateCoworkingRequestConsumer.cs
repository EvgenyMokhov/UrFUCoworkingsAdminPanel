using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.DTOs;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class CreateCoworkingRequestConsumer : IConsumer<CreateCoworkingRequest>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ServiceManager serviceManager;
        public CreateCoworkingRequestConsumer(IPublishEndpoint endpoint, IServiceProvider provider)
        {
            publishEndpoint = endpoint;
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<CreateCoworkingRequest> context)
        {
            CoworkingEdit coworking = new();
            CreateCoworkingResponse response = new();
            response.Id = context.Message.Id;
            await serviceManager.CoworkingService.CreateCoworkingAsync(coworking);
            response.ResponseData = coworking.Id;
            await publishEndpoint.Publish(response);
        }
    }
}
