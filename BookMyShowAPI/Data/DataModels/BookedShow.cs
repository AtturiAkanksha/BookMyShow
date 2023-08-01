using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    public class BookedShow
    {
        [Key]
        [Column("BookingId")]
        public Guid BookingId { get; set; }
        [Column("MovieName")]
        public string MovieName { get; set; }
        [Column("TheatreName")]
        public string TheatreName { get; set; }
        [Column("TheatreId")]
        public int? TheatreId { get; set; }
        [Column("MovieTimings")]
        public string MovieTimings { get; set; }
        [Column("TotalAmount")]
        public float TotalAmount { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("TotalSeats")]
        public int SeatsCount { get; set; }
        [Column("SeatsNames")]
        public string SeatNames { get; set; }
    }
}
