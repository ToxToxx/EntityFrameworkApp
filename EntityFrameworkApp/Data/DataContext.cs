using EntityFrameworkApp.Model;
using System.Data.Entity;

namespace EntityFrameworkApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DataContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.AddressObject)
                .WithMany()
                .HasForeignKey(s => s.AddressId);
        }
    }
}
