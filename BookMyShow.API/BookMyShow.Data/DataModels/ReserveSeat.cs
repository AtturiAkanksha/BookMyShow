using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("ReserveSeat")]
    public class ReserveSeat
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("SeatsNumber")]
        public string SeatNumber { get; set; }

        [Column("TheatreId")]
        public int TheatreId { get; set; }

        [Column("ShowTime")]
        public string ShowTime { get; set; }

        [Column("MovieId")]
        public int MovieId { get; set; }
    }
}
