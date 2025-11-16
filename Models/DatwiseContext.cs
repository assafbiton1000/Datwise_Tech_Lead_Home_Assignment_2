using System.Data.Entity;

namespace Datwise_Tech_Lead_Home_Assignment.Models
{
    public class DatwiseContext : DbContext
    {
        public DatwiseContext() : base("DatwiseContext") { }

        public DbSet<ReportData> ReportsData { get; set; }
        public DbSet<User> Users { get; set; }
    }
}