using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeetings.Domain.Entities;
public class MeetingItemList
{
    public IList<MeetingItem> Items { get; private set; } = new List<MeetingItem>();
}

public class MeetingList
{
    public IList<Meeting> Items { get; private set; } = new List<Meeting>();
}

public class MeetingItemStatusHistoryList
{
    public IList<MeetingItemStatusHistory> Items { get; private set; } = new List<MeetingItemStatusHistory>();
}
