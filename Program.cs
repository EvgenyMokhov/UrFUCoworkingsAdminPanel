using Microsoft.EntityFrameworkCore;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Data.Interfaces;
using UrFUCoworkingsAdminPanel.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    
var app = builder.Build();

// Configure the HTTP request pipeline.
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
