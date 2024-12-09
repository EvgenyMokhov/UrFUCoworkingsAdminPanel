using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsModels.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
	public class CoworkingService
	{
		private readonly IServiceProvider serviceProvider;
		public CoworkingService(IServiceProvider provider) => serviceProvider = provider;
		public async Task CreateCoworkingAsync(CoworkingDTO editModel)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Coworking coworking = new();
			coworking.Id = Guid.NewGuid();
			coworking.Name = editModel.Name;
			coworking.Opening = new TimeOnly(8, 30);
			coworking.Closing = new TimeOnly(17, 0);
			coworking.Zones = new();
			coworking.Settings = new();
			await dataManager.Coworkings.CreateCoworkingAsync(coworking);
		}

		public async Task<List<CoworkingDTO>> GetCoworkingsAsync(bool IncludeInactives)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			IEnumerable<Coworking> data = await dataManager.Coworkings.GetCoworkingsAsync();
			if (IncludeInactives)
				return data.Select(CoworkingDbToDTO).ToList();
			else 
				return data.Where(coworking => coworking.IsWorking).Select(CoworkingDbToDTO).ToList();
		}

		public async Task<List<Guid>> TryUpdateCoworkingAsync(CoworkingDTO coworkingDTO)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingDTO.Id);
			ZoneService zoneService = new(serviceProvider);
			List<Guid> result = new();
			if (!coworkingDTO.IsWorking && coworking.IsWorking)
			{
				result = new HashSet<Guid>((await dataManager.Reservations.GetReservationsOnPlacesAsync(coworking.Zones.SelectMany(zone => zone.Places).ToList())).Select(res => res.Id)).ToList();
				if (result.Count == 0)
				{
					foreach (Zone zone in coworking.Zones)
						await zoneService.SetZoneInactiveAsync(zone, scope);
					coworking.IsWorking = false;
				}
			}
			if (coworkingDTO.IsWorking && !coworking.IsWorking)
			{
				foreach (Zone zone in coworking.Zones)
					await zoneService.SetZoneActiveAsync(zone, scope);
				coworking.IsWorking = true;
			}
			coworking.Name = coworkingDTO.Name;
			coworking.Opening = coworkingDTO.Opening;
			coworking.Closing = coworkingDTO.Closing;
			await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
			return result;
        }

        public async Task<CoworkingDTO> GetCoworkingAsync(Guid id)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(id);
			CoworkingDTO editModel = new();
			editModel.Id = id;
			editModel.Name = coworking.Name;
			editModel.Opening = coworking.Opening;
			editModel.Closing = coworking.Closing;
			editModel.Zones = new();
			editModel.Settings = new();
			ZoneService zoneService = new(serviceProvider);
			CSService csService = new(serviceProvider);
			foreach (Zone zone in coworking.Zones)
				editModel.Zones.Add(await zoneService.DbZoneToDTO(zone));
			foreach (CoworkingSettings cs in coworking.Settings)
				editModel.Settings.Add(csService.DbCSToEdit(cs));
			return editModel;
		}

		public async Task<List<ReservationEdit>> UpdateCoworkingAsync(CoworkingDTO coworkingDTO)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingDTO.Id);
			List<ReservationEdit> result = new();
			if (coworkingDTO.IsWorking && !coworking.IsWorking)
				await SetCoworkingActiveAsync(coworking, scope);
            if (!coworkingDTO.IsWorking && coworking.IsWorking)
                result = await SetCoworkingInactiveAsync(coworking, scope);
            coworking.Name = coworkingDTO.Name;
            coworking.Opening = coworkingDTO.Opening;
			coworking.Closing = coworkingDTO.Closing;
			await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
			return result;
		}

		public async Task<List<ReservationEdit>> SetCoworkingInactiveAsync(Coworking coworking, IServiceScope scope)
		{
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            List<ReservationEdit> result = new();
            ZoneService zoneService = new(serviceProvider);
            foreach (Zone zone in coworking.Zones)
				result.AddRange(await zoneService.SetZoneInactiveAsync(zone, scope));
			result = result.DistinctBy(res => res.ReservationId).ToList();
            coworking.IsWorking = false;
            await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
            return result;
        }

        public async Task SetCoworkingActiveAsync(Coworking coworking, IServiceScope scope)
        {
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            ZoneService zoneService = new(serviceProvider);
            foreach (Zone zone in coworking.Zones)
                await zoneService.SetZoneActiveAsync(zone, scope);
            coworking.IsWorking = true;
			await dataManager.Coworkings.UpdateCoworkingAsync(coworking);
        }

        private CoworkingDTO CoworkingDbToDTO(Coworking coworking)
		{
			CoworkingDTO viewModel = new();
			viewModel.Id = coworking.Id;
			viewModel.Name = coworking.Name;
			viewModel.Opening = coworking.Opening;
			viewModel.Closing = coworking.Closing;
			viewModel.Zones = coworking.Zones.Select(zone => new ZoneDTO() { Id = zone.Id, Places = zone.Places.Select(place => new PlaceDTO() { Id = place.Id }).ToList() }).ToList();
			viewModel.Settings = coworking.Settings.Select(setting => new CSDTO() { Id = setting.Id, Closing = setting.Closing, Day = setting.Day, IsWorking = setting.IsWorking, Opening = setting.Opening }).ToList();
			viewModel.IsWorking = coworking.IsWorking;
			return viewModel;
		}

		public async Task<List<ReservationEdit>> DeleteCoworkingAsync(Guid coworkingId)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
			List<ReservationEdit> result = new();
			ZoneService zoneService = new(serviceProvider);
			ReservationService reservationService = new();
            result.AddRange((await dataManager.Reservations.GetReservationsOnPlacesAsync(coworking.Zones.SelectMany(zone => zone.Places).ToList())).Select(reservationService.ReservationToEdit));
            result = result.DistinctBy(res => res.ReservationId).ToList();
            await dataManager.Coworkings.DeleteCoworkingAsync(coworking);
			return result;
		}
	}
}
