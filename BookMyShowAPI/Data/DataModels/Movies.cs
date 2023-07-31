using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    [Table("Movies")]
    public class Movies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("MovieName")]
        public string? MovieName { get; set; }
        [Column("Languages")]
        public string Languages { get; set; }
        [Column("Hours")]
        public string Hours { get; set; }
        [Column("Genre")]
        public string Genre { get; set; }
        [Column("DateOfRelease")]
        public string DateOfRelease { get; set; }
        [Column("LocationNames")]
        public string LocationNames { get; set; }
        [Column("TheatresId")]
        [ForeignKey("theatres")]
        public int TheatresId { get; set; }
    }
}
