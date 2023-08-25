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
                optionsBuilder.UseSqlServer("BookMyShowConnectionString");
            }
        }

        public BookMyShowDbContext(DbContextOptions<BookMyShowDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Theatre> Theatres { get; set; }
        public virtual DbSet<Ticket> BookedShows { get; set; }
        public virtual DbSet<ReserveSeat> ReservedSeats { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
