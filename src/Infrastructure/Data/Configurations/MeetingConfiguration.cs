using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Infrastructure.Data.Configurations;
public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        // Configure properties and relationships for the Meeting entity
        builder.HasKey(m => m.Id);
        builder.Property(m => m.MeetingType).IsRequired();
        builder.Property(m => m.MeetingNumber).IsRequired();
        builder.Property(m => m.Date).IsRequired();
     /*   builder.Property(m => m.MeetingNumber)
                   .HasComputedColumnSql("CONCAT(SUBSTRING(MeetingType, 1, 1), CAST(Id AS NVARCHAR))")
                   .IsRequired();*/
        // Add more configurations as needed
    }
}
