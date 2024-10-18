namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public virtual List<Reservation> Reservations { get; set; } = new();
    }
}
