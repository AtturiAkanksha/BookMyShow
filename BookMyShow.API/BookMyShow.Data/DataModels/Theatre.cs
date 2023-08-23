using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("Theatre")]
    public class Theatre
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Rows")]
        public int Rows { get; set; }

        [Column("Columns")]
        public int Columns { get; set; }

        [Column("MovieIds")]
        public string MovieIds { get; set; }

        [Column("ShowTime")]
        public string ShowTime { get; set; }

        [Column("TicketPrice")]
        public float TicketPrice { get; set; }

        [Column("Location")]
        public string Location { get; set; }

    }
}
