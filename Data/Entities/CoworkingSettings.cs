﻿namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class CoworkingSettings
    {
        public int Id { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public int CoworkingId { get; set; }
        public virtual Coworking Coworking { get; set; } = null!;
    }
}
