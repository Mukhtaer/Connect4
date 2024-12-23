namespace Connect4App.Data
{
    using Connect4App.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Player>? Players { get; set; }
        public DbSet<Game>? Games { get; set; }
        public DbSet<Grid>? Grids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=connect4.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Host)
                .WithMany(p => p.HostedGames)
                .HasForeignKey(g => g.HostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Guest)
                .WithMany(p => p.GuestGames)
                .HasForeignKey(g => g.GuestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}