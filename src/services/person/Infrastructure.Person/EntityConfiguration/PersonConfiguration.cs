using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Person.EntityConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Domain.Person.Entities.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.Person.Entities.Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(11).IsRequired(false);
            builder.Property(p => p.Age).IsRequired();
        }
    }
}
