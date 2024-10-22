namespace UrFUCoworkingsAdminPanel.Models
{
    public class CSEdit
    {
        public int Id { get; set; }
        public DateOnly Day {  get; set; }
        public TimeOnly Opening { get; set; }
        public TimeOnly Closing { get; set; }
        public bool IsWorking { get; set; }
    }
}
