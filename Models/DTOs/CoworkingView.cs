using System.Net;

namespace UrFUCoworkingsAdminPanel.Models.DTOs
{
    public class CoworkingView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeOnly Opening { get; set; }
        public TimeOnly Closing { get; set; }
        public List<ZoneView> Zones { get; set; }
    }
}
