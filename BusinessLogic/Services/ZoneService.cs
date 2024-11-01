using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class ZoneService
    {
        private readonly DataManagerFactory DMFactory;
        private readonly IServiceProvider serviceProvider;
        public ZoneService(IServiceProvider provider)
        {
            DMFactory = new DataManagerFactory(provider);
            serviceProvider = provider;
        }

        public async Task<List<ZoneEdit>> GetZonesAsync(int coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            List<Zone> zones = await dataManager.Zones.GetZonesWithCoworkingIdAsync(coworkingId);
            return zones.Select(DbZoneToEdit).ToList();
        }

        public async Task CreateZoneAsync(int coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            Zone zone = new();
            zone.CoworkingId = coworkingId;
            zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            zone.Places = new();
            await dataManager.Zones.UpdateZoneAsync(zone);
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            coworking.Zones.Add(zone);
        }

        public async Task UpdateZoneAsync(int coworkingId, ZoneEdit zoneEdit)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            Zone zone = await EditToDb(coworkingId, zoneEdit);
            await dataManager.Zones.UpdateZoneAsync(zone);
            PlaceService placeService = new(serviceProvider);
            for (int i = 0; i < zoneEdit.PlacesCount; i++)
                zone.Places.Add(await placeService.CreatePlaceAsync(zone.Id));
        }

        public async Task DeleteZoneAsync(int zoneId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            await dataManager.Zones.DeleteZoneAsync(zoneId);
        }

        public ZoneEdit DbZoneToEdit(Zone zone)
        {
            ZoneEdit editModel = new();
            editModel.Id = zone.Id;
            editModel.PlacesCount = zone.Places.Count;
            return editModel;
        }

        private async Task<Zone> EditToDb(int coworkingId, ZoneEdit editModel)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManagerFactory DMFactory = new(serviceProvider);
            DataManager dataManager = DMFactory.Create();
            Zone zone = await dataManager.Zones.GetZoneAsync(editModel.Id);
            zone.Id = editModel.Id;
            zone.CoworkingId = coworkingId;
            zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            zone.Places = new();
            return zone;
        }
    }
}
