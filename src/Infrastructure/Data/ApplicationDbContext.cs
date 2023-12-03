using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackMeetings.Application.Common.Interfaces;
using TrackMeetings.Domain.Entities;
using TrackMeetings.Infrastructure.Data.Configurations;
using TrackMeetings.Infrastructure.Identity;

namespace TrackMeetings.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();



    public DbSet<MeetingItem> MeetingItems => Set<MeetingItem>();

    public DbSet<ResponsiblePerson> ResponsiblePersons => Set<ResponsiblePerson>();
    public DbSet<Meeting> Meetings => Set<Meeting>();

    public DbSet<MeetingType> MeetingTypes => Set<MeetingType>();

    public DbSet<MeetingItemStatusHistory> MeetingItemStatusHistories => Set<MeetingItemStatusHistory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

  /*      builder.ApplyConfiguration(new MeetingConfiguration());
        builder.ApplyConfiguration(new MeetingItemConfiguration());
        builder.ApplyConfiguration(new ResponsiblePersonConfiguration());*/
    }
}
