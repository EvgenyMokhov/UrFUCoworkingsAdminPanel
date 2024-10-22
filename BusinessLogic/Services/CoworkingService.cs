using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Implementations;
using UrFUCoworkingsAdminPanel.Models;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CoworkingService
    {
        private readonly DataManager dataManager;
        public CoworkingService(DataManager dataManager) => this.dataManager = dataManager;
        public async Task CreateCoworkingAsync(CoworkingEdit editModel)
        {
            Coworking coworking = new();
            coworking.Id = editModel.Id;
            coworking.Name = editModel.Name;
            coworking.Opening = new TimeOnly(8, 30);
            coworking.Closing = new TimeOnly(17, 0);
            coworking.Zones = new();
            coworking.Settings = new();
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        public async Task<List<CoworkingView>> GetCoworkingsAsync()
        {
            IEnumerable<Coworking> data = await dataManager.Coworkings.GetCoworkingsAsync();
            return data.Select(CoworkingDbToView).ToList();
        }

        public async Task<CoworkingEdit> GetCoworkingAsync(int id)
        {
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(id);
            CoworkingEdit editModel = new();
            editModel.Id = id;
            editModel.Name = coworking.Name;
            editModel.Opening = coworking.Opening;
            editModel.Closing = coworking.Closing;
            editModel.Zones = new();
            editModel.Settings = new();
            ZoneService zoneService = new(dataManager);
            CSService csService = new(dataManager);
            foreach (Zone zone in coworking.Zones)
                editModel.Zones.Add(zoneService.DbZoneToEdit(zone));
            foreach (CoworkingSettings cs in coworking.Settings)
                editModel.Settings.Add(csService.DbCSToEdit(cs));
            return editModel;
        }

        public async Task UpdateCoworkingAsync(CoworkingEdit editModel)
        {
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(editModel.Id);
            coworking.Name = editModel.Name;
            coworking.Opening = editModel.Opening;
            coworking.Closing = editModel.Closing;
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        private CoworkingView CoworkingDbToView(Coworking coworking)
        {
            CoworkingView viewModel = new();
            viewModel.Id = coworking.Id;
            viewModel.Name = coworking.Name;
            viewModel.Opening = coworking.Opening;
            viewModel.Closing = coworking.Closing;
            viewModel.Zones = coworking.Zones.Select(zone => new ZoneView() { Id = zone.Id, Places = zone.Places.Select(place => new PlaceView() { Id = place.Id }).ToList() }).ToList();
            return viewModel;
        }

        public void Update(Coworking coworking, Zone zone)
        {
            bool flag = true;
            for (int i = 0; i < coworking.Zones.Count; i++)
                if (zone.Id == coworking.Zones[i].Id)
                {
                    flag = false;
                    coworking.Zones[i] = zone;
                    break;
                }
            if (flag) 
                coworking.Zones.Add(zone);
        }

        public void Update(Coworking coworking, CoworkingSettings settings)
        {
            bool flag = true;
            for (int i = 0; i < coworking.Settings.Count; i++)
                if (settings.Id == coworking.Zones[i].Id)
                {
                    flag = false;
                    coworking.Settings[i] = settings;
                    break;
                }
            if (flag)
                coworking.Settings.Add(settings);
        }
    }
}
