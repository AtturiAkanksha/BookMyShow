using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    [Table("Theatres")]
    public class Theatres
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("TheatreName")]
        public string? TheatreName { get; set; }
        [Column("TheatreRows")]
        public int? TheatreRows { get; set; }
        [Column("TheatreColumns")]
        public int? TheatreColumns { get; set; }
        [Column("ListOfMovies")]
        public List<Movies>? ListOfMovies { get; set; }
        [Column("MovieTimings")]
        public string? MovieTimings { get; set; }
        [Column("TicketPrice")]
        public int TicketPrice { get; set; }
    }
}
