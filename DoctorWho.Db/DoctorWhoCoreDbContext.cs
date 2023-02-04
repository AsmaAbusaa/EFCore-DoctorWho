using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;
public class DoctorWhoCoreDbContext : DbContext
{
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Companion> Companions { get; set; }
    public DbSet<Enemy> Enemies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DoctorWhoCore"
        );
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}

}
