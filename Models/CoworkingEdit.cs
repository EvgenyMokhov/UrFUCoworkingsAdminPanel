using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Models
{
    public class CoworkingEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ZoneEdit> Zones { get; set; }
        public List<CSEdit> Settings { get; set; }
    }
}
