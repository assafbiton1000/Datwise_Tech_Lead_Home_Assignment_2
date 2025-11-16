using System;

namespace Datwise_Tech_Lead_Home_Assignment.Models
{
    public class ReportData
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public decimal ValueAmount { get; set; }
        public DateTime EventDate { get; set; }
    }
}