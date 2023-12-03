using TrackMeetings.Application.Common.Exceptions;
using TrackMeetings.Application.Common.Interfaces;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.AddMeetingItem.Commands.AddMeetingItemCommand;

public record AddMeetingItemCommand : IRequest<object>
{
    public int MeetingId { get; init; }
    public required string Description { get; init; }
    public DateTime DueDate { get; init; }
    public required string PersonResponsible { get; init; }
}

/*public class AddMeetingItemCommandCommandValidator : AbstractValidator<AddMeetingItemCommandCommand>
{
    public AddMeetingItemCommandCommandValidator()
    {
    }
}*/

public class AddMeetingItemCommandHandler : IRequestHandler<AddMeetingItemCommand, object>
{
    private readonly IApplicationDbContext _context;

    public AddMeetingItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(AddMeetingItemCommand request, CancellationToken cancellationToken)
    {
        // Check if the meeting exists
        var meeting = await _context.Meetings.FindAsync(request.MeetingId);
        if (meeting == null)
        {
            throw new MeetingNotFoundException();
        }

        var responsiblePerson = _context.ResponsiblePersons
            .FirstOrDefault(rp => rp.Name == request.PersonResponsible);

        if (responsiblePerson == null)
        {
            responsiblePerson = new ResponsiblePerson { Name = request.PersonResponsible };
            _context.ResponsiblePersons.Add(responsiblePerson);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // Create a new meeting item based on the command
        var newMeetingItem = new MeetingItem
        {   Meeting  = meeting,
            Description = request.Description,
            DueDate = request.DueDate,
            ResponsiblePerson = responsiblePerson,
            /*    StatusHistory = "Not Started" // Set default status or customize as needed*/
        };

        // Add the initial status to the status history
        newMeetingItem.StatusHistory?.Add(new MeetingItemStatusHistory
        {
            MeetingItem = newMeetingItem,// Assign the MeetingItem navigation property,
            Status = "Not Started",
            DateSet = DateTime.UtcNow
        });

        meeting.MeetingItems.Add(newMeetingItem);

        // Save the changes to the repository
        await _context.SaveChangesAsync(cancellationToken);

        return newMeetingItem.Id;
    }
}
