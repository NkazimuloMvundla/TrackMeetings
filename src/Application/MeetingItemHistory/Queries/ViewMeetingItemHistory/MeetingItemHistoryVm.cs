namespace TrackMeetings.Application.MeetingItemHistory.Queries.ViewMeetingItemHistory;

public class MeetingItemHistoryVm
{
    public required string MeetingItemDescription { get; set; }
    public required string PersonResponsible { get; set; }
    public DateTime DueDate { get; set; }

    public List<MeetingItemStatusDto> StatusHistory { get; set; } = new List<MeetingItemStatusDto>();
}

public class MeetingItemStatusDto
{
    public string? Status { get; set; }
    public DateTime DateSet { get; set; }
}
