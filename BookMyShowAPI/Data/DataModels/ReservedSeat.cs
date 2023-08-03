using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    [Table("ReservedSeat")]
    public class ReservedSeat
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("SeatsNumber")]
        public int SeatNumber { get; set; }
        [Column("TheatreId")]
        public int TheatreId { get; set; }
    }
}
