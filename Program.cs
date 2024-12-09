using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsAdminPanel.Data;
using MassTransit;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Settings;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Zones;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Places;
using UrFUCoworkingsModels.Data;
using RabbitMQ.Client;
using UrFUCoworkingsAdminPanel.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPlaces, Places>();
builder.Services.AddTransient<IReservations, Reservations>();
builder.Services.AddTransient<ICoworkingsSettings, CoworkingsSettings>();
builder.Services.AddTransient<IZones, Zones>();
builder.Services.AddTransient<ICoworkings, Coworkings>();
builder.Services.AddScoped<DataManager>();
builder.Services.AddHostedService<DeleteDataBackgroundService>();
var connection = builder.Configuration["ConnectionStrings:MSSQL"];
builder.Services.AddDbContext<EFDBContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddMassTransit(x =>
{ 
    x.AddConsumer<CreateCoworkingRequestConsumer>().Endpoint(e => e.Name = "create-coworking-requests");
    x.AddConsumer<DeleteCoworkingRequestConsumer>().Endpoint(e => e.Name = "delete-coworking-requests");
    x.AddConsumer<GetCoworkingByIdRequestConsumer>().Endpoint(e => e.Name = "get-coworking-by-id-requests");
    x.AddConsumer<GetCoworkingsRequestConsumer>().Endpoint(e => e.Name = "get-coworkings-requests");
    x.AddConsumer<UpdateCoworkingRequestConsumer>().Endpoint(e => e.Name = "update-coworking-requests");
    x.AddConsumer<TryUpdateCoworkingRequestConsumer>().Endpoint(e => e.Name = "try-update-coworking-requests");
    x.AddConsumer<CreateSettingRequestConsumer>().Endpoint(e => e.Name = "create-setting-requests");
    x.AddConsumer<DeleteSettingRequestConsumer>().Endpoint(e => e.Name = "delete-setting-requests");
    x.AddConsumer<GetSettingsRequestConsumer>().Endpoint(e => e.Name = "get-settings-requests");
    x.AddConsumer<TryUpdateSettingRequestConsumer>().Endpoint(e => e.Name = "try-update-setting-requests");
    x.AddConsumer<UpdateSettingAnywayRequestConsumer>().Endpoint(e => e.Name = "update-setting-anyway-requests");
    x.AddConsumer<CreateZoneRequestConsumer>().Endpoint(e => e.Name = "create-zone-requests");
    x.AddConsumer<DeleteZoneRequestConsumer>().Endpoint(e => e.Name = "delete-zone-requests");
    x.AddConsumer<GetZonesRequestConsumer>().Endpoint(e => e.Name = "get-zones-requests");
    x.AddConsumer<UpdateZoneRequestConsumer>().Endpoint(e => e.Name = "update-zone-requests");
    x.AddConsumer<TryUpdateZoneRequestConsumer>().Endpoint(e => e.Name = "try-update-zone-requests");
    x.AddConsumer<CreatePlaceRequestConsumer>().Endpoint(e => e.Name = "create-place-requests");
    x.AddConsumer<DeletePlaceRequestConsumer>().Endpoint(e => e.Name = "delete-place-requests");
    x.AddConsumer<GetPlacesRequestConsumer>().Endpoint(e => e.Name = "get-places-requests");
    x.AddConsumer<UpdatePlaceRequestConsumer>().Endpoint(e => e.Name = "update-place-requests");
    x.AddConsumer<TryUpdatePlaceRequestConsumer>().Endpoint(e => e.Name = "try-update-place-requests");
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "vh9", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ExchangeType = ExchangeType.Fanout;
        cfg.ConfigureEndpoints(context);
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminPanel API ver. 1.1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
