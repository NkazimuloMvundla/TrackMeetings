using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Infrastructure.Data.Configurations;
public class ResponsiblePersonConfiguration : IEntityTypeConfiguration<ResponsiblePerson>
{
    public void Configure(EntityTypeBuilder<ResponsiblePerson> builder)
    {
        builder.HasKey(rp => rp.Id);
        builder.Property(rp => rp.Name).IsRequired();

      /*  // Seed responsible persons
        builder.HasData(
            new ResponsiblePerson { Id = 1, Name = "John Doe" },
            new ResponsiblePerson { Id = 2, Name = "Jane Smith" }
            // Add more persons as needed
        );*/
    }
}

