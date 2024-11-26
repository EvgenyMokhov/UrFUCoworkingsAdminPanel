using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsModels.Requests.Coworkings;
using UrFUCoworkingsModels.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class DeleteCoworkingRequestConsumer : IConsumer<DeleteCoworkingRequest>
    {
        private readonly ServiceManager serviceManager;
        public DeleteCoworkingRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<DeleteCoworkingRequest> context)
        {
            await serviceManager.CoworkingService.DeleteCoworkingAsync(context.Message.CoworkingId);
            await context.RespondAsync(new DeleteCoworkingResponse());
        }
    }
}
