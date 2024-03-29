using System;

namespace OneBan_TMS.Models.DTOs.TimeEntry
{
    public class TimeEntryGetDto
    {
        public int TesId { get; set; }
        public DateTime TesCreatedAt { get; set; }
        public DateTime TesUpdatedAt { get; set; }
        public DateTime TesEntryDate { get; set; }
        public TimeSpan TesEntryTime { get; set; }
        public string TesDescription { get; set; }
        public int? TesIdProjectTask { get; set; }
        public int? TesIdTicket { get; set; }
    }
}