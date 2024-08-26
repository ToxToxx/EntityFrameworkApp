using EntityFrameworkApp.Model;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

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

        public void CreateStudent(Student student, Address address)
        {
            var connection = Database.Connection;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CreateStudent";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                command.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                command.Parameters.Add(new SqlParameter("@Patronymic", student.Patronymic));
                command.Parameters.Add(new SqlParameter("@Name", address.Name));
                command.Parameters.Add(new SqlParameter("@City", address.City));
                command.Parameters.Add(new SqlParameter("@State", address.State));
                command.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));


                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
