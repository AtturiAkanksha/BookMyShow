using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("Movie")]
    public class Movie
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Language")]
        public string Language { get; set; }

        [Column("Duration")]
        public string Duration { get; set; }

        [Column("Genre")]
        public string Genre { get; set; }

        [Column("DateOfRelease")]
        public DateTime DateOfRelease { get; set; }
    }
}
