using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public class Models
    {

    }
    public class ReportRow
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public decimal ValueAmount { get; set; }
        public System.DateTime EventDate { get; set; }
    }

}