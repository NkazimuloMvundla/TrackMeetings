using TrackMeetings.Application.Common.Exceptions;
using TrackMeetings.Application.Common.Interfaces;

namespace TrackMeetings.Application.MeetingItemHistory.Queries.ViewMeetingItemHistory;

public record ViewMeetingItemHistoryQuery : IRequest<MeetingItemHistoryVm>
{
    public int MeetingItemId { get; init; }
}

public class ViewMeetingItemHistoryQueryValidator : AbstractValidator<ViewMeetingItemHistoryQuery>
{
    public ViewMeetingItemHistoryQueryValidator()
    {
    }
}

public class ViewMeetingItemHistoryQueryHandler : IRequestHandler<ViewMeetingItemHistoryQuery, MeetingItemHistoryVm>
{
    private readonly IApplicationDbContext _context;

    public ViewMeetingItemHistoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MeetingItemHistoryVm> Handle(ViewMeetingItemHistoryQuery request, CancellationToken cancellationToken)
    {
        // Find the existing meeting item with its history
        var meetingItemWithHistory = await _context.MeetingItems
            .Include(mi => mi.ResponsiblePerson)
            .Include(mi => mi.StatusHistory)
            .FirstOrDefaultAsync(mi => mi.Id == request.MeetingItemId);


        if (meetingItemWithHistory == null)
        {
            // Throw the MeetingItemNotFoundException
            throw new MeetingItemNotFoundException();
        }

        // Map the relevant information to the result object
        var result = new MeetingItemHistoryVm
        {
            MeetingItemDescription = meetingItemWithHistory.Description,
            PersonResponsible = meetingItemWithHistory.ResponsiblePerson.Name,
            DueDate = meetingItemWithHistory.DueDate,
            StatusHistory = meetingItemWithHistory.StatusHistory?
            .Select(status => new MeetingItemStatusDto
            {
                Status = status?.Status ?? "N/A",
                DateSet = status?.DateSet ?? DateTime.MinValue
            }).ToList() ?? new List<MeetingItemStatusDto>()
        };

        return result;
    }
}
