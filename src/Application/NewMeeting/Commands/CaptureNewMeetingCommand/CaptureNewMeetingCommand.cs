using TrackMeetings.Application.Common.Interfaces;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.NewMeeting.Commands.CaptureNewMeetingCommand;

public record CaptureNewMeetingCommandCommand : IRequest<object>
{
    public required string MeetingType { get; set; }
    public DateTime DateTime { get; set; }

    public List<int>? CarriedForwardItems { get; set; }
}

/*public class CaptureNewMeetingCommandCommandValidator : AbstractValidator<CaptureNewMeetingCommandCommand>
{
    private readonly IApplicationDbContext _context;
    public CaptureNewMeetingCommandCommandValidator(IApplicationDbContext context)
    {
        _context = context;
    }
}*/

public class CaptureNewMeetingCommandCommandHandler : IRequestHandler<CaptureNewMeetingCommandCommand, object>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CaptureNewMeetingCommandCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<object> Handle(CaptureNewMeetingCommandCommand request, CancellationToken cancellationToken)
    {
        // Handle the logic for creating a new meeting
        var newMeeting = new Meeting
        {
            MeetingType = request.MeetingType,
            Date = DateTime.Now, // Use the current date
            MeetingItems = new List<MeetingItem>(),
        };

        // Optionally, handle carried forward items
        if (request.CarriedForwardItems != null)
        {
            foreach (var itemId in request.CarriedForwardItems)
            {
                var itemToCarryForward = _context.MeetingItems.FirstOrDefault(mi => mi.Id == itemId);
                if (itemToCarryForward != null)
                {
                    // You may need to adjust properties such as status when carrying forward
                    newMeeting.MeetingItems.Add(new MeetingItem
                    {
                        Meeting = newMeeting,
                      //  MeetingId = newMeeting.Id,
                        Description = itemToCarryForward.Description,
                        DueDate = itemToCarryForward.DueDate,
                        ResponsiblePerson = itemToCarryForward.ResponsiblePerson,
                        // Status = "Carried Forward" // Set default status or customize as needed
                    });
                }
            }
        }

        // Save the meeting to the repository to get the MeetingId
        _context.Meetings.Add(newMeeting);
        await _context.SaveChangesAsync(cancellationToken);

        // Now that MeetingId is available, update the MeetingNumber
        newMeeting.MeetingNumber = GenerateMeetingNumber(request.MeetingType, newMeeting.Id);

        // Save the meeting again to update the MeetingNumber
        await _context.SaveChangesAsync(cancellationToken);

        // Return the new meeting id
        return newMeeting.Id;
    }

    // Add the GenerateMeetingNumber method here
    public static string GenerateMeetingNumber(string meetingType, int meetingId)
    {
        return $"{meetingType?.Substring(0, 1)}-{meetingId:D2}";
    }


}
