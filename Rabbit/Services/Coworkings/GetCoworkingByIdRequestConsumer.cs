﻿using MassTransit;
using UrFUCoworkingsAdminPanel.BusinessLogic;
using UrFUCoworkingsAdminPanel.Models.Requests.Coworkings;
using UrFUCoworkingsAdminPanel.Models.Responses.Coworkings;

namespace UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings
{
    public class GetCoworkingByIdRequestConsumer : IConsumer<GetCoworkingByIdRequest>
    {
        private readonly ServiceManager serviceManager;
        public GetCoworkingByIdRequestConsumer(IServiceProvider provider) => serviceManager = new(provider);
        public async Task Consume(ConsumeContext<GetCoworkingByIdRequest> context)
        {
            GetCoworkingByIdResponse response = new();
            response.ResponseData = await serviceManager.CoworkingService.GetCoworkingAsync(context.Message.CoworkingId);
            await context.RespondAsync(response);
        }
    }
}
