using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class ZoneService
    {
        private readonly DataManager dataManager;
        public ZoneService(DataManager dataManager) => this.dataManager = dataManager;

        public async Task<List<ZoneEdit>> GetZonesAsync(int coworkingId)
        {
            List<Zone> zones = await dataManager.Zones.GetZonesWithCoworkingIdAsync(coworkingId);
            return zones.Select(DbZoneToEdit).ToList();
        }

        public async Task CreateZoneAsync(int coworkingId)
        {
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
            Zone zone = await EditToDb(coworkingId, zoneEdit);
            await dataManager.Zones.UpdateZoneAsync(zone);
            PlaceService placeService = new(dataManager);
            foreach (PlaceEdit place in zoneEdit.Places)
                zone.Places.Add(await placeService.CreatePlaceAsync(zone.Id));
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            for (int i = 0; i < coworking.Zones.Count; i++)
                if (coworking.Zones[i].Id == zone.Id)
                {
                    coworking.Zones[i] = zone;
                    break;
                }
        }

        public async Task DeleteZoneAsync(int coworkingId, int zoneId)
        {
            await dataManager.Zones.DeleteZoneAsync(zoneId);
        }

        public ZoneEdit DbZoneToEdit(Zone zone)
        {
            ZoneEdit editModel = new();
            editModel.Id = zone.Id;
            editModel.Places = new();
            PlaceService placeService = new(dataManager);
            foreach (Place place in zone.Places)
                editModel.Places.Add(placeService.DbPlaceToEdit(place));
            return editModel;
        }

        private async Task<Zone> EditToDb(int coworkingId, ZoneEdit editModel)
        {
            Zone zone = await dataManager.Zones.GetZoneAsync(editModel.Id);
            zone.Id = editModel.Id;
            zone.CoworkingId = coworkingId;
            zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            zone.Places = new();
            return zone;
        }
    }
}
