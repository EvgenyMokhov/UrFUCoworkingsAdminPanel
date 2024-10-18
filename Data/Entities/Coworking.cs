namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    public class Coworking
    {
        public int Id { get; set; }
        public virtual List<Place> Places { get; set; } = null!;
    }
}
