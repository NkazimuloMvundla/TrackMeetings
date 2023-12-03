using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeetings.Domain.Entities;
public class ResponsiblePerson : BaseAuditableEntity
{
    public int ResponsiblePersonId { get; set; }
    public required string Name { get; set; }
}
