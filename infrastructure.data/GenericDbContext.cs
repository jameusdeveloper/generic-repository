using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public  class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}