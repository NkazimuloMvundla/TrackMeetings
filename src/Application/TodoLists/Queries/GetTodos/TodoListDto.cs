using TrackMeetings.Application.MeetingItemHistory.Queries.ViewMeetingItemHistory;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.TodoLists.Queries.GetTodos;

public class TodoListDto
{
    public TodoListDto()
    {
        Items = Array.Empty<TodoItemDto>();
    }

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<TodoItemDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, TodoListDto>();
        }
    }
}

public class MeetingItemListDto
{
    public MeetingItemListDto()
    {
        Items = Array.Empty<MeetingItemDto>();
    }

    public IReadOnlyCollection<MeetingItemDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MeetingItemList, MeetingItemListDto>();
        }
    }
}

public class MeetingListDto
{
    public MeetingListDto()
    {
        Items = Array.Empty<MeetingDto>();
    }

    public IReadOnlyCollection<MeetingDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MeetingList, MeetingListDto>();
        }
    }
}

public class MeetingItemStatusHistoryListDto
{
    public MeetingItemStatusHistoryListDto()
    {
        Items = Array.Empty<MeetingItemStatusHistoryDto>();
    }

    public IReadOnlyCollection<MeetingItemStatusHistoryDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MeetingItemStatusHistoryList, MeetingItemStatusHistoryListDto>();
        }
    }
}
