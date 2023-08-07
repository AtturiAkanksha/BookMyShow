using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("BookedShow")]
    public class BookedShow
    {
        [Column("BookingId")]
        [Key]
        public Guid BookingId { get; set; }
        [Column("MovieName")]
        public string MovieName { get; set; }
        [Column("MovieId")]
        public int MovieId { get; set; }
        [Column("TheatreName")]
        public string TheatreName { get; set; }
        [Column("TheatreId")]
        public int TheatreId { get; set; }
        [Column("MovieTimings")]
        public string MovieTimings { get; set; }
        [Column("TotalAmount")]
        public float TotalAmount { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("SeatsCount")]
        public int SeatsCount { get; set; }
        [Column("SeatsNames")]
        public string SeatNames { get; set; }
    }
}
