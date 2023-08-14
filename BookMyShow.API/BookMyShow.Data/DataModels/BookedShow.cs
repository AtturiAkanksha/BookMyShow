using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [Column("BookingId")]
        public Guid BookingId { get; set; }

        [Column("MovieName")]
        public string MovieName { get; set; }

        [Column("MovieId")]
        public int MovieId { get; set; }

        [Column("TheatreName")]
        public string TheatreName { get; set; }

        [Column("TheatreId")]
        public int TheatreId { get; set; }

        [Column("ShowTime")]
        public string ShowTime { get; set; }

        [Column("TotalAmount")]
        public float TotalAmount { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("SeatNumbers")]
        public string SeatNumbers { get; set; }
    }
}
