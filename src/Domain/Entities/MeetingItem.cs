using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMeetings.Domain.Entities;

/*public class MeetingItem : BaseAuditableEntity
{
    public int MeetingItemId { get; set; }
    public required string Description { get; set; } // Item description
    public DateTime DueDate { get; set; } // Item due date

    // Foreign key for the related meeting
    public int MeetingId { get; set; }

    // Navigation property for the related meeting
    public required Meeting Meeting { get; set; }

    public int ResponsiblePersonId { get; set; }

    public required ResponsiblePerson ResponsiblePerson { get; set; }

    public ICollection<MeetingItemStatusHistory>? StatusHistory { get; set; }
    public DateTime? CompletedDate { get; set; }
}*/

public class MeetingItem : BaseAuditableEntity
{

    [Required]
    public required string Description { get; set; } // Item description

    public DateTime DueDate { get; set; } // Item due date

/*    public int MeetingId { get; set; }*/

    // Navigation property for the related meeting
    [ForeignKey("MeetingId")]
    public required Meeting Meeting { get; set; }

    public int ResponsiblePersonId { get; set; }

    // Navigation property for the related person responsible
    [ForeignKey("ResponsiblePersonId")]
    public required ResponsiblePerson ResponsiblePerson { get; set; }

    public ICollection<MeetingItemStatusHistory>? StatusHistory { get; set; }
    public DateTime? CompletedDate { get; set; }
}
