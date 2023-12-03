using TrackMeetings.Application.Common.Exceptions;
using TrackMeetings.Application.Common.Interfaces;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.AddMeetingItem.Commands.UpdateMeetingItemStatusCommand;

public record UpdateMeetingItemStatusCommand : IRequest<object>
{
    public int MeetingItemId { get; init; }
    public required string NewStatus { get; init; }
}

public class UpdateMeetingItemStatusCommandHandler : IRequestHandler<UpdateMeetingItemStatusCommand, object>
{
    private readonly IApplicationDbContext _context;

    public UpdateMeetingItemStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(UpdateMeetingItemStatusCommand request, CancellationToken cancellationToken)
    {
        // Find the existing meeting item
        var existingMeetingItem = await _context.MeetingItems
            .FirstOrDefaultAsync(mi => mi.Id == request.MeetingItemId);


        if (existingMeetingItem == null)
        {
            // Throw the MeetingItemNotFoundException
            throw new MeetingItemNotFoundException();
        }
        existingMeetingItem.StatusHistory?.Add(new MeetingItemStatusHistory
        {
            Status = request.NewStatus,
            DateSet = DateTime.UtcNow, // Use UTC time for consistency
            MeetingItem = existingMeetingItem // Assign the MeetingItem navigation property
        });

        // Save the changes to the repository
        await _context.SaveChangesAsync(cancellationToken);

        return existingMeetingItem.Id;
    }
}
