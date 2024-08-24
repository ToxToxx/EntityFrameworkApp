using EntityFrameworkApp.Model;
using System.Data.Entity;

namespace EntityFrameworkApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DataContext() { }
    }
}
