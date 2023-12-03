using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.MeetingItemHistory.Queries.ViewMeetingItemHistory;

public class MeetingItemDto
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MeetingItem, MeetingItemDto>();
        }
    }

    public int MeetingItemId { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public required ResponsiblePerson PersonResponsible { get; set; }
    public int MeetingId { get; set; }

    public string? Status { get; set; }
    public DateTime? CompletedDate { get; set; }
}

public class MeetingDto
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Meeting, MeetingDto>();
        }
    }

    public int MeetingId { get; set; }
    public required string MeetingType { get; set; }
    public string MeetingNumber => $"{MeetingType.ToString().Substring(0, 1)}{MeetingId}";
    public DateTime Date { get; set; }

    public required ICollection<MeetingItem> MeetingItems { get; set; }

    public ICollection<MeetingItem>? CarriedForwardItems { get; set; }
}

public class MeetingItemStatusHistoryDto
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MeetingItemStatusHistory, MeetingItemStatusHistoryDto>();
        }
    }

    public string? Status { get; set; }
    public DateTime DateSet { get; set; }

    public int MeetingItemId { get; set; }
    public required MeetingItem MeetingItem { get; set; }
}
