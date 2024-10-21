using System.Net;

namespace UrFUCoworkingsAdminPanel.Models
{
    public class CoworkingView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ZoneView> Zones { get; set; }
    }
}
