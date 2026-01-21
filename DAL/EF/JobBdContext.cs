using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.EF
{
    public class JobBdContext : DbContext
    {
        public JobBdContext(DbContextOptions<JobBdContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Disable cascade delete
            foreach (var foreignKey in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
