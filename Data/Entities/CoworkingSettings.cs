namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class CoworkingSettings
    {
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public bool IsDefault { get; set; }
        public int CoworkingId { get; set; }
        public virtual Coworking Coworking { get; set; } = null!;
    }
}
