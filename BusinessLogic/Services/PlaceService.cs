using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsModels.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
	public class PlaceService
	{
		private readonly IServiceProvider serviceProvider;
		public PlaceService(IServiceProvider provider) => serviceProvider = provider;

		public async Task CreatePlaceAsync(Guid zoneId)
		{
			using IServiceScope scope = serviceProvider.CreateScope();
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Place place = new() {Id = Guid.NewGuid(), Zone = await dataManager.Zones.GetZoneAsync(zoneId), Name = "New place", IsWorking = true };
			await dataManager.Places.CreatePlaceAsync(place);
		}

		public async Task<List<PlaceDTO>> GetPlacesAsync(Guid zoneId)
		{
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Zone zone = await dataManager.Zones.GetZoneAsync(zoneId);
			return (await Task.WhenAll(zone.Places.Select(async place => await DbPlaceToDTO(place)))).ToList();
        }

		public async Task<PlaceDTO> DbPlaceToDTO(Place place)
		{
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            return new() { Id = place.Id, Name = place.Name, IsWorking = place.IsWorking, ReservationsCount = place.Reservations.Count };
		}

		public async Task<List<ReservationEdit>> SetPlaceInactiveAsync(Place place, IServiceScope scope)
		{
			DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			List<ReservationEdit> result = new();
			ReservationService reservationService = new();
			foreach (Reservation reservation in place.Reservations)
			{
				result.Add(reservationService.ReservationToEdit(reservation));
				await dataManager.Reservations.DeleteReservationAsync(reservation);
			}
			place.IsWorking = false;
			await dataManager.Places.UpdatePlaceAsync(place);
			return result;
		}

		public async Task SetPlaceActiveAsync(Place place, IServiceScope scope)
		{
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			place.IsWorking = true;
			await dataManager.Places.UpdatePlaceAsync(place);
        }

		public async Task<List<ReservationEdit>> UpdatePlaceAsync(PlaceDTO placeDTO)
		{
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			List<ReservationEdit> result = new();
 			Place place = await dataManager.Places.GetPlaceAsync(placeDTO.Id);
			place.Name = placeDTO.Name;
			if (placeDTO.IsWorking && !place.IsWorking)
				await SetPlaceActiveAsync(place, scope);
			if (!placeDTO.IsWorking && place.IsWorking)
				result = await SetPlaceInactiveAsync(place, scope);
			await dataManager.Places.UpdatePlaceAsync(place);
			return result;
        }

		public async Task<List<Guid>> TryUpdatePlaceAsync(PlaceDTO placeDTO)
		{
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			Place place = await dataManager.Places.GetPlaceAsync(placeDTO.Id);
			List<Guid> result = new();
			if (placeDTO.IsWorking && !place.IsWorking)
				place.IsWorking = true;
			if (!placeDTO.IsWorking && place.IsWorking)
			{
				result = place.Reservations.Select(res => res.Id).ToList();
				if (result.Count == 0)
					place.IsWorking = false;
			}
			place.Name = placeDTO.Name;
			await dataManager.Places.UpdatePlaceAsync(place);
			return result;
        }
		public async Task<List<ReservationEdit>> DeletePlaceAsync(Place place, IServiceScope scope)
		{
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            ReservationService reservationService = new();
            List<ReservationEdit> result = new();
            foreach (Reservation reservation in place.Reservations)
            {
                result.Add(reservationService.ReservationToEdit(reservation));
                await dataManager.Reservations.DeleteReservationAsync(reservation);
            }
			await dataManager.Places.DeletePlaceAsync(place);
			return result;
        }

		public async Task<List<ReservationEdit>> DeletePlaceAsync(Guid placeId)
		{
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
			return await DeletePlaceAsync(await dataManager.Places.GetPlaceAsync(placeId), scope);
        }
	}
}
