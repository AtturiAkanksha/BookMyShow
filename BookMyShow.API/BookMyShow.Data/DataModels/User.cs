using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Data.DataModels
{
    [Table("AppUser")]
    public class User
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Role")]
        public string Role { get; set; }
    }

}
