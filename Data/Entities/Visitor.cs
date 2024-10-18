using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UrFUCoworkingsAdminPanel.Data.Entities
{
    [Index(nameof(Id))]
    [Index(nameof(UserId), nameof(ReservationId))]
    public class Visitor
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        [Key]
        public Guid Id { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; } = null!;
    }
}
