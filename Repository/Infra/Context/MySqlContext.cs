using AchadosPerdidosApi.Repository.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace AchadosPerdidosApi.Repository.Infra.Context
{
    public class MySqlContext : DbContext
    {
        private static DbContextOptions<MySqlContext> GetConfigContext()
        {
            string connectionString = Startup.Configuration.GetConnectionString("MySqlConnection");
            var optionsBuilder = new DbContextOptionsBuilder<MySqlContext>();
            optionsBuilder.UseMySQL(connectionString);
            return optionsBuilder.Options;
        }

        public MySqlContext() : base(GetConfigContext())
        {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Course>().ToTable("Course");
        //     modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //     modelBuilder.Entity<Student>().ToTable("Student");
        // }

        public DbSet<User> User { get; set; }
    }
}