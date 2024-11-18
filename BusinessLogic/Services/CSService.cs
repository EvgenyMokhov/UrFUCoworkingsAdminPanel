using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Models.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CSService
    {
        private readonly IServiceProvider serviceProvider;
        public CSService(IServiceProvider provider) => serviceProvider = provider;

        public CSEdit DbCSToEdit(CoworkingSettings settings)
        {
            return new() { Id = settings.Id, Day = settings.Day, Opening = settings.Opening, Closing = settings.Closing, IsWorking = settings.IsWorking };
        }

        public async Task<List<CSEdit>> GetSettingsAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            List<CoworkingSettings> cs = await dataManager.CoworkingsSettings.GetCoworkingSettingsAsync(coworkingId);
            return cs.Select(DbCSToEdit).ToList();
        }

        public async Task CreateSettingAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            CoworkingSettings setting = new();
            setting.Id = Guid.NewGuid();
            setting.Day = new();
            setting.Opening = new();
            setting.Closing = new();
            setting.IsWorking = true;
            setting.CoworkingId = coworkingId;
            await dataManager.CoworkingsSettings.CreateCoworkingSettingsAsync(setting);
        }

        public async Task DeleteSettingAsync(Guid settingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            await dataManager.CoworkingsSettings.DeleteCoworkingSettingsAsync(settingId);
        }

        public async Task<List<(Guid UserId, Guid ReservationId)>> CSSaveAsync(Guid coworkingId, CSEdit model)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            CoworkingSettings setting = await dataManager.CoworkingsSettings.GetCoworkingSettingAsync(model.Id);
            EditToDb(coworkingId, model, setting);
            await dataManager.CoworkingsSettings.UpdateCoworkingSettingsAsync(setting);
            List<Reservation> reservations = await dataManager.Reservations.GetReservationsOnDateAsync(model.Day);
            List<(Guid UserId, Guid ReservationId)> userIds = new();
            foreach (Reservation reservation in reservations) 
            {
                TimeOnly reservationBegin = TimeOnly.FromDateTime(reservation.ReservationBegin);
                TimeOnly reservationEnd = TimeOnly.FromDateTime(reservation.ReservationEnd);
                if (!model.IsWorking || !(reservationBegin >= model.Opening && reservationEnd <= model.Closing))
                {
                    List<Visit> visits = await dataManager.Visits.GetVisitsByReservationIdAsync(reservation.Id);
                    foreach (Visit visit in visits)
                        userIds.Add(new() { UserId = visit.UserId, ReservationId = reservation.Id });
                    await dataManager.Reservations.DeleteReservationAsync(reservation.Id);
                }
            }
            return userIds;
        }

        public async Task<List<Guid>> TryCSSaveAsync(Guid coworkingId, CSEdit model)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = new(serviceProvider);
            List<Reservation> reservations = await dataManager.Reservations.GetReservationsOnDateAsync(model.Day);
            List<Guid> reservationIds = new();
            foreach (Reservation reservation in reservations)
            {
                TimeOnly reservationBegin = TimeOnly.FromDateTime(reservation.ReservationBegin);
                TimeOnly reservationEnd = TimeOnly.FromDateTime(reservation.ReservationEnd);
                if (!model.IsWorking || !(reservationBegin >= model.Opening && reservationEnd <= model.Closing))
                    reservationIds.Add(reservation.Id);
            }
            if (reservationIds.Count == 0)
            {
                CoworkingSettings setting = await dataManager.CoworkingsSettings.GetCoworkingSettingAsync(model.Id);
                EditToDb(coworkingId, model, setting);
                await dataManager.CoworkingsSettings.UpdateCoworkingSettingsAsync(setting);
            }
            return reservationIds;
        }

        private void EditToDb(Guid coworkingId, CSEdit model, CoworkingSettings settings)
        {
            settings.CoworkingId = coworkingId;
            settings.Day = model.Day;
            settings.Opening = model.Opening;
            settings.Closing = model.Closing;
            settings.IsWorking = model.IsWorking;
            settings.Id = model.Id;
        }
    }
}
