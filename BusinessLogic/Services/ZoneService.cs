using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class ZoneService
    {
        private readonly IServiceProvider serviceProvider;
        public ZoneService(IServiceProvider provider) => serviceProvider = provider;

        public async Task<List<ZoneEdit>> GetZonesAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            List<Zone> zones = await dataManager.Zones.GetZonesWithCoworkingIdAsync(coworkingId);
            return zones.Select(DbZoneToEdit).ToList();
        }

        public async Task CreateZoneAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            Zone zone = new();
            zone.Id = Guid.NewGuid();
            zone.CoworkingId = coworkingId;
            zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            zone.Places = new();
            await dataManager.Zones.CreateZoneAsync(zone);
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            coworking.Zones.Add(zone);
        }

        public async Task UpdateZoneAsync(Guid coworkingId, ZoneEdit zoneEdit)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            Zone zone = await EditToDb(coworkingId, zoneEdit);
            await dataManager.Zones.UpdateZoneAsync(zone);
            PlaceService placeService = new(serviceProvider);
            for (int i = 0; i < zoneEdit.PlacesCount; i++)
                zone.Places.Add(await placeService.CreatePlaceAsync(zone.Id));
        }

        public async Task DeleteZoneAsync(Guid zoneId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            await dataManager.Zones.DeleteZoneAsync(zoneId);
        }

        public ZoneEdit DbZoneToEdit(Zone zone)
        {
            ZoneEdit editModel = new();
            editModel.Id = zone.Id;
            editModel.PlacesCount = zone.Places.Count;
            return editModel;
        }

        private async Task<Zone> EditToDb(Guid coworkingId, ZoneEdit editModel)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            Zone zone = await dataManager.Zones.GetZoneAsync(editModel.Id);
            zone.Id = editModel.Id;
            zone.CoworkingId = coworkingId;
            zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            zone.Places = new();
            return zone;
        }
    }
}
