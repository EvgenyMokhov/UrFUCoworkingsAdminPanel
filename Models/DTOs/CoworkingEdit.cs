using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Models.DTOs
{
    public class CoworkingEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeOnly Opening { get; set; }
        public TimeOnly Closing { get; set; }
        public List<ZoneEdit> Zones { get; set; }
        public List<CSEdit> Settings { get; set; }
    }
}
