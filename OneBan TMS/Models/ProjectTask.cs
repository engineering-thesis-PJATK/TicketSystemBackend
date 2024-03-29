﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OneBan_TMS.Models
{
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            TimeEntries = new HashSet<TimeEntry>();
        }

        public int PtkId { get; set; }
        public string PtkContent { get; set; }
        public decimal PtkEstimatedCost { get; set; }
        public int PtkIdProject { get; set; }
        public int PtkIdEmployeeTeam { get; set; }
        public int PtkIdProjectTaskStatus { get; set; }

        public virtual EmployeeTeam PtkIdEmployeeTeamNavigation { get; set; }
        public virtual Project PtkIdProjectNavigation { get; set; }
        public virtual ProjectTaskStatus PtkIdProjectTaskStatusNavigation { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
