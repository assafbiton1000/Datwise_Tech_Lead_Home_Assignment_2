using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Datwise_Tech_Lead_Home_Assignment.Models
{
    public class DatwiseContext : DbContext
    {
        public DatwiseContext() : base("DefaultConnection") { }

        public DbSet<ReportData> ReportsData { get; set; }
        public DbSet<User> Users { get; set; }

        public IEnumerable<ReportData> GetPagedReports(int pageNumber, int pageSize, string category, string region, System.DateTime? fromDate, System.DateTime? toDate)
        {
            var p1 = new SqlParameter("@PageNumber", pageNumber);
            var p2 = new SqlParameter("@PageSize", pageSize);
            var p3 = new SqlParameter("@CategoryFilter", (object)category ?? System.DBNull.Value);
            var p4 = new SqlParameter("@RegionFilter", (object)region ?? System.DBNull.Value);
            var p5 = new SqlParameter("@FromDate", (object)fromDate ?? System.DBNull.Value);
            var p6 = new SqlParameter("@ToDate", (object)toDate ?? System.DBNull.Value);


            return this.Database.SqlQuery<ReportData>("EXEC sp_GetReportPaged @PageNumber, @PageSize, @CategoryFilter, @RegionFilter, @FromDate, @ToDate", p1, p2, p3, p4, p5, p6).ToList();
        }
    }


}