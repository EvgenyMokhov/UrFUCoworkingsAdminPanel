namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public List<Place> Places { get; set; } = null!;
        public int CoworkingId { get; set; }
        public virtual Coworking Coworking { get; set; } = null!;
    }
}
