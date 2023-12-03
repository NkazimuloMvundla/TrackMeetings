using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.NewMeeting.Commands.CaptureNewMeetingCommand;

public record CaptureNewMeetingCommandCommand : IRequest<object>
{
}

public class CaptureNewMeetingCommandCommandValidator : AbstractValidator<CaptureNewMeetingCommandCommand>
{
    public CaptureNewMeetingCommandCommandValidator()
    {
    }
}

public class CaptureNewMeetingCommandCommandHandler : IRequestHandler<CaptureNewMeetingCommandCommand, object>
{
    private readonly IApplicationDbContext _context;

    public CaptureNewMeetingCommandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(CaptureNewMeetingCommandCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
