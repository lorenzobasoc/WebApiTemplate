using WebApiTemplate.Entities;
using WebApiTemplate.Entities.Base;

namespace WebApiTemplate.DataAccess;

public class Db(DbContextOptions<Db> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        ConfigureUsers(builder);
    }

    private static void ConfigureUsers(ModelBuilder builder) {
        // builder.OneToMany<User, Product>(x => x.Products, x => x.UserId);
    }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default) {
        var modifiedEntities = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Modified);
        foreach (var entry in modifiedEntities) {
            entry.Property(nameof(BaseEntity.UpdatedAt)).CurrentValue = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(ct);
    }
}
