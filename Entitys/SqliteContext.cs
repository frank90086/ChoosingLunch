using Microsoft.EntityFrameworkCore;

namespace ChoosingBot.Entitys
{
    public class SqliteContext : DbContext
    {

        public SqliteContext(DbContextOptions<SqliteContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<EatedList> EatedLists { get; set; }
        public virtual DbSet<RestaurantList> RestaurantLists { get; set; }
    }
}