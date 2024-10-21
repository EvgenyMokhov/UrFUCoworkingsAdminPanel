using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class ZoneService
    {
        private readonly DataManager dataManager;
        public ZoneService(DataManager dataManager) => this.dataManager = dataManager;

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
    }
}
