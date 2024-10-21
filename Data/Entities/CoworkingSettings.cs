﻿namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class CoworkingSettings
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Opening { get; set; }
        public TimeOnly Closing { get; set; }
        public int CoworkingId { get; set; }
        public virtual Coworking Coworking { get; set; } = null!;
    }
}
