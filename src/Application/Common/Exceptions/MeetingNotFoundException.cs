namespace TrackMeetings.Application.Common.Exceptions;

public class MeetingNotFoundException : Exception
{
    public MeetingNotFoundException() : base("Meeting not found.")
    {
    }

    public MeetingNotFoundException(string message) : base(message)
    {
    }

    public MeetingNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class MeetingItemNotFoundException : Exception
{
    public MeetingItemNotFoundException() : base("Meeting Item not found.")
    {
    }

    public MeetingItemNotFoundException(string message) : base(message)
    {
    }

    public MeetingItemNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
