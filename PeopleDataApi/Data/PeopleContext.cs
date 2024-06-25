using Microsoft.EntityFrameworkCore;
using PeopleDataApi.Models;

namespace PeopleDataApi.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People").HasKey(p => p.NumberId);
        }
    }
}
