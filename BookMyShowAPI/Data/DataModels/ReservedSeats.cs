using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    public class ReservedSeats
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("SeatNumber")]
        public int SeatNumber { get; set; }
        [Column("TheatreId")]
        public int TheatreId { get; set; }
    }
}
