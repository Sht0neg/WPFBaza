using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WPFD
{
    public class Context:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=12345;database=posts", new MySqlServerVersion(new Version(8, 4, 0)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post { PostId=1, Title="Ьарк", Text="l"}
                );
        }
    }
}
