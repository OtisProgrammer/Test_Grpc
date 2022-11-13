using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Person.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Person.Context
{
    public class PersonDbContext:DbContext
    {
        public DbSet<Domain.Person.Entities.Person> People { get; set; }
        public PersonDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PersonConfiguration().Configure(modelBuilder.Entity<Domain.Person.Entities.Person>());
        }
    }
}
