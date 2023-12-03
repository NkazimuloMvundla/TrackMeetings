using TrackMeetings.Application.Common.Exceptions;
using TrackMeetings.Application.Common.Interfaces;
using TrackMeetings.Domain.Entities;

namespace TrackMeetings.Application.AddMeetingItem.Commands.EditMeetingItemCommand;

public record EditMeetingItemCommand : IRequest<object>
{
    public int MeetingItemId { get; init; }
    public required string Description { get; init; }
    public DateTime DueDate { get; init; }
    public required string PersonResponsible { get; init; }
}

public class EditMeetingItemCommandValidator : AbstractValidator<EditMeetingItemCommand>
{
    public EditMeetingItemCommandValidator()
    {
        RuleFor(x => x.MeetingItemId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.DueDate).NotEmpty();
        RuleFor(x => x.PersonResponsible).NotEmpty();
    }
}

public class EditMeetingItemCommandHandler : IRequestHandler<EditMeetingItemCommand, object>
{
    private readonly IApplicationDbContext _context;

    public EditMeetingItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(EditMeetingItemCommand request, CancellationToken cancellationToken)
    {
        // Find the existing meeting item
        var existingMeetingItem = await _context.MeetingItems
            .Include(mi => mi.ResponsiblePerson)
            .FirstOrDefaultAsync(mi => mi.Id == request.MeetingItemId);


        if (existingMeetingItem == null)
        {
            // Throw the MeetingItemNotFoundException
            throw new MeetingItemNotFoundException();
        }

        // Update the meeting item based on the command
        existingMeetingItem.Description = request.Description;
        existingMeetingItem.DueDate = request.DueDate;

        // Find or create the ResponsiblePerson
        var responsiblePerson = _context.ResponsiblePersons
            .FirstOrDefault(rp => rp.Name == request.PersonResponsible);

        if (responsiblePerson == null)
        {
            responsiblePerson = new ResponsiblePerson { Name = request.PersonResponsible };
            _context.ResponsiblePersons.Add(responsiblePerson);
            await _context.SaveChangesAsync(cancellationToken);
        }

        existingMeetingItem.ResponsiblePerson = responsiblePerson;

        // Save the changes to the repository
        await _context.SaveChangesAsync(cancellationToken);

        return existingMeetingItem.Id;
    }
}
