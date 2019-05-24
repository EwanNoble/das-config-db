using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SFA.DAS.Config.Database
{
    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantGroupMembership>()
                .HasKey(pk => new { pk.TenantGroupId, pk.TenantObjectId });

            modelBuilder.Entity<TenantGroupMembership>()
                .HasOne(s => s.TenantGroup)
                .WithMany(s => s.TenantGroupMembers)
                .HasForeignKey(s => s.TenantGroupId)
                .OnDelete(DeleteBehavior.Restrict); // Not ideal

            modelBuilder.Entity<TenantGroupMembership>()
                .HasOne(s => s.TenantObjectMember)
                .WithMany(s => s.TenantGroupMemberships)
                .HasForeignKey(s => s.TenantObjectId)
                .OnDelete(DeleteBehavior.Restrict); // Not ideal
        }

        public DbSet<TenantObject> TenantObjects { get; set; }
        public DbSet<TenantGroup> TenantGroups { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }
    }

    public class ConfigDbContextFactory : IDesignTimeDbContextFactory<ConfigDbContext>
    {
        public ConfigDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ConfigDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ConfigDbContext(optionsBuilder.Options);
        }
    }
}
