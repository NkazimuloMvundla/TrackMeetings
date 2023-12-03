namespace TrackMeetings.Domain.Entities;
public class MeetingItemStatusHistory : BaseAuditableEntity
{
    public int MeetingItemStatusHistoryId { get; set; }
    public string? Status { get; set; } = null!; // Ensure non-null
    public DateTime DateSet { get; set; }

    public int MeetingItemId { get; set; }
    public required MeetingItem MeetingItem { get; set; }
}
