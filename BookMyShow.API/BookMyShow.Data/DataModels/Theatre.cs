using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("Theatre")]
    public class Theatre
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("TheatreName")]
        public string TheatreName { get; set; }
        [Column("TheatreRows")]
        public int TheatreRows { get; set; }
        [Column("TheatreColumns")]
        public int TheatreColumns { get; set; }
        [Column("MovieIds")]
        public string MovieIds { get; set; }
        [Column("MovieTimings")]
        public string MovieTimings { get; set; }
        [Column("TicketPrice")]
        public float TicketPrice { get; set; }
        [Column("LocationName")]
        public string LocationName { get; set; }

    }
}
