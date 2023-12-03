using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Infrastructure.Data.Configurations;
public class MeetingItemConfiguration : IEntityTypeConfiguration<MeetingItem>
{
    public void Configure(EntityTypeBuilder<MeetingItem> builder)
    {
        // Configure properties and relationships for the MeetingItem entity
  /*      builder.HasKey(mi => mi.MeetingItemId);
        builder.Property(mi => mi.Description).IsRequired();
        builder.Property(mi => mi.DueDate).IsRequired();
        builder.Property(mi => mi.ResponsiblePersonId).IsRequired();

        // Configure relationship with Meeting entity
        builder.HasOne(mi => mi.Meeting)
            .WithMany(m => m.MeetingItems)
            .HasForeignKey(mi => mi.MeetingId);*/

        // Configure relationship with ResponsiblePerson entity
        /*   builder.HasOne(mi => mi.ResponsiblePerson)
               .WithMany()
               .HasForeignKey(mi => mi.ResponsiblePerson.ResponsiblePersonId);*/

        // Add more configurations as needed


        // Configure properties and relationships for the MeetingItem entity
   /*     builder.HasKey(mi => mi.Id);
        builder.Property(mi => mi.Description).IsRequired();
        builder.Property(mi => mi.DueDate).IsRequired();
        builder.Property(mi => mi.ResponsiblePersonId).IsRequired();

        // Configure relationship with Meeting entity
        builder.HasOne(mi => mi.Meeting)
            .WithMany(m => m.MeetingItems)
            .HasForeignKey(mi => mi.MeetingId);

        // Configure relationship with ResponsiblePerson entity
        builder.HasOne(mi => mi.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(mi => mi.ResponsiblePersonId);*/

        // Add more configurations as needed
    }
}
