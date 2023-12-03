using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    public DbSet<ResponsiblePerson> ResponsiblePersons { get; }

    public DbSet<MeetingItem> MeetingItems { get; }

    public DbSet<Meeting> Meetings { get; }

    public DbSet<MeetingType> MeetingTypes { get; }

    public DbSet<MeetingItemStatusHistory> MeetingItemStatusHistories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
