namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ReservatorId { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
        public virtual List<Visitor> Visitors { get; set; } = new();
        public virtual List<Place> Places { get; set; } = new();
    }
}
