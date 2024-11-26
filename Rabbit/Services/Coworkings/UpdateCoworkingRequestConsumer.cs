using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Coworkings;
using UrFUCoworkingsModels.Responses.Coworkings;

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
