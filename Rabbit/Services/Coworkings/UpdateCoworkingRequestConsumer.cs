using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class UpdateCoworkingRequestConsumer : IConsumer<UpdateCoworkingRequest>
    {
        private readonly ServiceManager serviceManager;
        public UpdateCoworkingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);

        public async Task Consume(ConsumeContext<UpdateCoworkingRequest> context)
        {
            await serviceManager.CoworkingService.UpdateCoworkingAsync(context.Message.RequestData);
            await context.RespondAsync(new UpdateCoworkingResponse());
        }
    }
}
