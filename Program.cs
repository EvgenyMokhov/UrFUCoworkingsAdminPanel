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
    x.AddConsumer<CreateCoworkingRequestConsumer>();
    x.AddConsumer<DeleteCoworkingRequestConsumer>();
    x.AddConsumer<GetCoworkingByIdRequestConsumer>();
    x.AddConsumer<GetCoworkingsRequestConsumer>();
    x.AddConsumer<UpdateCoworkingRequestConsumer>();
    x.AddConsumer<CreateSettingRequestConsumer>();
    x.AddConsumer<DeleteSettingRequestConsumer>();
    x.AddConsumer<GetSettingsRequestConsumer>();
    x.AddConsumer<TryUpdateSettingRequestConsumer>();
    x.AddConsumer<UpdateSettingAnywayRequestConsumer>();
    x.AddConsumer<CreateZoneRequestConsumer>();
    x.AddConsumer<DeleteZoneRequestConsumer>();
    x.AddConsumer<GetZonesRequestConsumer>();
    x.AddConsumer<UpdateZoneRequestConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
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
