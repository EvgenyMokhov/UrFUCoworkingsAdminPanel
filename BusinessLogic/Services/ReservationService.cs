using UrFUCoworkingsModels.Data.Entities;
using UrFUCoworkingsModels.DTOs;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class ReservationService
    {
        public ReservationEdit ReservationToEdit(Reservation reservation)
        {
            ReservationEdit editModel = new();
            editModel.ReservationId = reservation.Id;
            editModel.ReservatorId = reservation.ReservatorId;
            editModel.ReservationDay = DateOnly.FromDateTime(reservation.ReservationBegin);
            editModel.ReservationBegin = TimeOnly.FromDateTime(reservation.ReservationBegin);
            editModel.ReservationEnd = TimeOnly.FromDateTime(reservation.ReservationEnd);
            editModel.PlacesIds = reservation.Places.Select(place => place.Id).ToList();
            editModel.UserIds = reservation.Visits.Select(visit => visit.UserId).ToList();
            return editModel;
        }
    }
}
