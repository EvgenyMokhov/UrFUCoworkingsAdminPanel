using UrFUCoworkingsAdminPanel.Data.Implementations;

namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class Coworking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Zone> Zones { get; set; } = null!;
        public virtual List<CoworkingsSettings> CoworkingsSettings { get; set; } = null!;
    }
}
