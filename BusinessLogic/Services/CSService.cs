using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsModels.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class CSService
    {
        private readonly IServiceProvider serviceProvider;
        public CSService(IServiceProvider provider) => serviceProvider = provider;

        public CSDTO DbCSToEdit(CoworkingSettings settings)
        {
            return new() { Id = settings.Id, Day = settings.Day, Opening = settings.Opening, Closing = settings.Closing, IsWorking = settings.IsWorking };
        }

        public async Task<List<CSDTO>> GetSettingsAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            List<CoworkingSettings> cs = await dataManager.CoworkingsSettings.GetCoworkingSettingsAsync(coworkingId);
            return cs.Select(DbCSToEdit).ToList();
        }

        public async Task CreateSettingAsync(Guid coworkingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            Coworking coworking = await dataManager.Coworkings.GetCoworkingAsync(coworkingId);
            CoworkingSettings setting = new();
            setting.Id = Guid.NewGuid();
            setting.Day = new();
            setting.Opening = coworking.Opening;
            setting.Closing = coworking.Closing;
            setting.IsWorking = true;
            setting.CoworkingId = coworkingId;
            await dataManager.CoworkingsSettings.CreateCoworkingSettingsAsync(setting);
        }

        public async Task DeleteSettingAsync(Guid settingId)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            CoworkingSettings settings = await dataManager.CoworkingsSettings.GetCoworkingSettingAsync(settingId);
            await dataManager.CoworkingsSettings.DeleteCoworkingSettingsAsync(settings);
        }

        public async Task<List<ReservationEdit>> CSSaveAsync(CSDTO model)
        { 
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            CoworkingSettings setting = await dataManager.CoworkingsSettings.GetCoworkingSettingAsync(model.Id);
            EditToDb(model, setting);
            await dataManager.CoworkingsSettings.UpdateCoworkingSettingsAsync(setting);
            List<Reservation> reservations = await dataManager.Reservations.GetReservationsOnDateAsync(model.Day);
            List<ReservationEdit> result = new();
            foreach (Reservation reservation in reservations) 
            {
                TimeOnly reservationBegin = TimeOnly.FromDateTime(reservation.ReservationBegin);
                TimeOnly reservationEnd = TimeOnly.FromDateTime(reservation.ReservationEnd);
                if (!model.IsWorking || !(reservationBegin >= model.Opening && reservationEnd <= model.Closing))
                {
                    result.Add(new ReservationService().ReservationToEdit(reservation));
                    await dataManager.Reservations.DeleteReservationAsync(reservation);
                }
            }
            return result;
        }

        public async Task<List<Guid>> TryCSSaveAsync(CSDTO model)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
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
                EditToDb(model, setting);
                await dataManager.CoworkingsSettings.UpdateCoworkingSettingsAsync(setting);
            }
            return reservationIds;
        }

        private void EditToDb(CSDTO model, CoworkingSettings settings)
        {
            settings.Day = model.Day;
            if (model.IsWorking)
            {
                settings.Opening = model.Opening;
                settings.Closing = model.Closing;
            }
            else
            {
                settings.Opening = settings.Coworking.Opening;
                settings.Closing = settings.Coworking.Closing;
            }
            settings.IsWorking = model.IsWorking;
            settings.Id = model.Id;
        }
    }
}
