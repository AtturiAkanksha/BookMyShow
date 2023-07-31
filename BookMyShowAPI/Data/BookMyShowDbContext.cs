using Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookMyShowDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TL599\\SQLEXPRESS;Initial Catalog=BookMyShowDb;Integrated " +
                    "Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        public BookMyShowDbContext(DbContextOptions<BookMyShowDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Theatres> Theatres { get; set; }
        public virtual DbSet<BookedShows> BookedShows { get; set; }
        public virtual DbSet<ReservedSeats> ReservedSeats { get; set; }
    }
}
