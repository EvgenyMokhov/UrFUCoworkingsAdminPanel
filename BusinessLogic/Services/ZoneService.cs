using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsModels.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
	public class ZoneService
	{
		private readonly IServiceProvider serviceProvider;
		public ZoneService(IServiceProvider provider) => serviceProvider = provider;

		public async Task<List<ZoneDTO>> GetZonesAsync(Guid coworkingId)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			List<Zone> zones = await dataManager.Zones.GetZonesWithCoworkingIdAsync(coworkingId);
			return (await Task.WhenAll(zones.Select(async zone => await DbZoneToDTO(zone)))).ToList();
		}

		public async Task CreateZoneAsync(Guid coworkingId)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Zone zone = new();
			zone.Id = Guid.NewGuid();
			zone.CoworkingId = coworkingId;
			zone.Coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
			zone.Places = new();
			await dataManager.Zones.CreateZoneAsync(zone);
		}

		public async Task<List<ReservationEdit>> UpdateZoneAsync(ZoneDTO zoneDTO)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Zone zone = await dataManager.Zones.GetZoneAsync(zoneDTO.Id);
			List<ReservationEdit> result = new();
			if (zoneDTO.IsWorking && !zone.IsWorking)
				await SetZoneActiveAsync(zone, scope);
			if (!zoneDTO.IsWorking && zone.IsWorking)
				result = await SetZoneInactiveAsync(zone, scope);
			zone.Name = zoneDTO.Name;
			await dataManager.Zones.UpdateZoneAsync(zone);
			return result;
		}

		public async Task<List<ReservationEdit>> SetZoneInactiveAsync(Zone zone, IServiceScope scope)
		{
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			List<ReservationEdit> result = new();
			PlaceService placeService = new(serviceProvider);
			foreach (Place place in zone.Places)
				result.AddRange(await placeService.SetPlaceInactiveAsync(place, scope));
            result = result.DistinctBy(res => res.ReservationId).ToList();
            zone.IsWorking = false;
			await dataManager.Zones.UpdateZoneAsync(zone);
			return result;
		}

		public async Task SetZoneActiveAsync(Zone zone, IServiceScope scope)
		{
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			PlaceService placeService = new(serviceProvider);
			foreach (Place place in zone.Places)
				await placeService.SetPlaceActiveAsync(place, scope);
			zone.IsWorking = true;
            await dataManager.Zones.UpdateZoneAsync(zone);
        }

        public async Task<List<Guid>> TryUpdateZoneAsync(ZoneDTO zoneDTO) 
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Zone zone = await dataManager.Zones.GetZoneAsync(zoneDTO.Id);
			PlaceService placeService = new(serviceProvider);
			List<Guid> result = new();
			if (!zoneDTO.IsWorking && zone.IsWorking)
			{
				result = (await dataManager.Reservations.GetReservationsOnPlacesAsync(zone.Places)).Select(res => res.Id).ToList();
				if (result.Count == 0)
				{
					foreach (Place place in zone.Places)
						await placeService.SetPlaceInactiveAsync(place, scope);
					zone.IsWorking = false;
				}
			}
			if (zoneDTO.IsWorking && !zone.IsWorking)
			{
				foreach (Place place in zone.Places)
					await placeService.SetPlaceActiveAsync(place, scope);
				zone.IsWorking = true;
			}
			zone.Name = zoneDTO.Name;
			await dataManager.Zones.UpdateZoneAsync(zone);
			return result;
		}

		public async Task<List<ReservationEdit>> DeleteZoneAsync(Zone zone, IServiceScope scope)
		{
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			ReservationService reservationService = new();
			List<Reservation> reservationsInZone = await dataManager.Reservations.GetReservationsOnPlacesAsync(zone.Places);
			List<ReservationEdit> result = new();
			foreach (Reservation reservation in reservationsInZone)
			{
				result.Add(reservationService.ReservationToEdit(reservation));
				await dataManager.Reservations.DeleteReservationAsync(reservation);
			}
			await dataManager.Zones.DeleteZoneAsync(zone);
			return result;
		}

		public async Task<List<ReservationEdit>> DeleteZoneAsync(Guid zoneId)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			return await DeleteZoneAsync(await dataManager.Zones.GetZoneAsync(zoneId), scope);
		}

		public async Task<ZoneDTO> DbZoneToDTO(Zone zone)
		{
            PlaceService placeService = new(serviceProvider);
            ZoneDTO DTOModel = new();
			DTOModel.Id = zone.Id;
			DTOModel.Name = zone.Name;
			DTOModel.IsWorking = zone.IsWorking;
			foreach (Place place in zone.Places)
				DTOModel.Places.Add(await placeService.DbPlaceToDTO(place));
			return DTOModel;
		}
	}
}
