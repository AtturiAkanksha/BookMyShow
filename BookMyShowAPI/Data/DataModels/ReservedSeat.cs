using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    public class ReservedSeat
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("SeatsNumber")]
        public int SeatNumber { get; set; }
        [Column("TheatreId")]
        public int TheatreId { get; set; }
    }
}
