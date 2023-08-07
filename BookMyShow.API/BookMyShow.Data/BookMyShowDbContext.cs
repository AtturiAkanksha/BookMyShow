using BookMyShow.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Data
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

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Theatre> Theatre { get; set; }
        public virtual DbSet<BookedShow> BookedShows { get; set; }
        public virtual DbSet<ReserveSeat> ReservedSeats { get; set; }
    }
}
