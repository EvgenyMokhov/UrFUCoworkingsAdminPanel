using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Models
{
    public class CoworkingEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Zone> Zones { get; set; }
    }
}
