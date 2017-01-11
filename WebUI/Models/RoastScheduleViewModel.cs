using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class RoastScheduleViewModel
    {
        public Guid RoastScheduleId { get; private set; }
        public DateTime RoastWeekStartsOn { get; private set; }

        public RoastScheduleViewModel(Guid roastScheduleId, DateTime roastWeekStartsOn)
        {
            RoastScheduleId = roastScheduleId;
            RoastWeekStartsOn = roastWeekStartsOn;
        }
    }
}