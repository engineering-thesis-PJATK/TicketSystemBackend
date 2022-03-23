﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OneBan_TMS.Models
{
    public partial class Status
    {
        public Status()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int StsId { get; set; }
        public string StsName { get; set; }
        public string StsDescription { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
