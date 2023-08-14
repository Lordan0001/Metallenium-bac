using Microsoft.EntityFrameworkCore;

namespace Metall_Fest.models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options): base(options) { }
        public DbSet<Band> bands { get; set; }
        public DbSet<Album> albums { get; set; }
        public DbSet<Song> songs { get; set; }

        public DbSet<User> users { get; set; }
    }
}
