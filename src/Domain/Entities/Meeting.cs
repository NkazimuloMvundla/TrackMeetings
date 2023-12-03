using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMeetings.Domain.Entities;

public class Meeting : BaseAuditableEntity
{
    public required string MeetingType { get; set; } // MANCO, Finance, PTL, etc.

    // public required string MeetingNumber { get; set; } // F32, F33, etc.
    /*    public string MeetingNumber => $"{MeetingType.ToString().Substring(0, 1)}{Id}"; // Computed property*/

    public string? MeetingNumber { get; set; }
    public DateTime Date { get; set; }

    // Navigation property for meeting items
    public required ICollection<MeetingItem> MeetingItems { get; set; }
    [NotMapped]
    public ICollection<MeetingItem>? CarriedForwardItems { get; set; }
}
