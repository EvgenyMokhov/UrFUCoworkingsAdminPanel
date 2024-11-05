using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsAdminPanel.Data;
using MassTransit;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Coworkings;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Settings;
using UrFUCoworkingsAdminPanel.Rabbit.Services.Zones;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPlaces, Places>();
builder.Services.AddTransient<IReservations, Reservations>();
builder.Services.AddTransient<IUsers, Users>();
builder.Services.AddTransient<IVisits, Visits>();
builder.Services.AddTransient<ICoworkingsSettings, CoworkingsSettings>();
builder.Services.AddTransient<IZones, Zones>();
builder.Services.AddTransient<ICoworkings, Coworkings>();
builder.Services.AddScoped<DataManager>();
var connection = builder.Configuration["ConnectionStrings:MSSQL"];
builder.Services.AddDbContext<EFDBContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateCoworkingRequestConsumer>().Endpoint(e => e.Name = "create-coworking-requests-queue");
    x.AddConsumer<DeleteCoworkingRequestConsumer>().Endpoint(e => e.Name = "delete-coworking-requests-queue");
    x.AddConsumer<GetCoworkingByIdRequestConsumer>().Endpoint(e => e.Name = "get-coworking-by-id-requests-queue");
    x.AddConsumer<GetCoworkingsRequestConsumer>().Endpoint(e => e.Name = "get-coworkings-requests-queue");
    x.AddConsumer<UpdateCoworkingRequestConsumer>().Endpoint(e => e.Name = "update-coworking-requests-queue");
    x.AddConsumer<CreateSettingRequestConsumer>().Endpoint(e => e.Name = "create-setting-requests-queue");
    x.AddConsumer<DeleteSettingRequestConsumer>().Endpoint(e => e.Name = "delete-setting-requests-queue");
    x.AddConsumer<GetSettingsRequestConsumer>().Endpoint(e => e.Name = "get-settings-requests-queue");
    x.AddConsumer<TryUpdateSettingRequestConsumer>().Endpoint(e => e.Name = "try-update-setting-requests-queue");
    x.AddConsumer<UpdateSettingAnywayRequestConsumer>().Endpoint(e => e.Name = "update-setting-anyway-requests-queue");
    x.AddConsumer<CreateZoneRequestConsumer>().Endpoint(e => e.Name = "create-zone-requests-queue");
    x.AddConsumer<DeleteZoneRequestConsumer>().Endpoint(e => e.Name = "delete-zone-requests-queue");
    x.AddConsumer<GetZonesRequestConsumer>().Endpoint(e => e.Name = "get-zones-requests-queue");
    x.AddConsumer<UpdateZoneRequestConsumer>().Endpoint(e => e.Name = "update-zone-requests-queue");
    x.UsingInMemory((context, cfg) =>
    {
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
