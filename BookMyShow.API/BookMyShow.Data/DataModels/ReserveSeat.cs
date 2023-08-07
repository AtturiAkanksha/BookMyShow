using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("ReservedSeat")]
    public class ReserveSeat
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("SeatsNumber")]
        public int SeatNumber { get; set; }
        [Column("TheatreId")]
        public int TheatreId { get; set; }
        [Column("MovieTime")]
        public string MovieTime { get; set; }
    }
}
