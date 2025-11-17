using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Datwise_Tech_Lead_Home_Assignment.Models
{
    public class DatwiseContext : DbContext
    {
        public DatwiseContext() : base("DefaultConnection") { }
        public DatwiseContext(DbConnection connection) : base(connection, true) { }
        public DbSet<ReportData> ReportsData { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="category"></param>
        /// <param name="region"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="region"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public IEnumerable<ReportData> GetReportsForCharts(
            string category = null,
            string region = null,
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            var p1 = new SqlParameter("@CategoryFilter", (object)category ?? DBNull.Value);
            var p2 = new SqlParameter("@RegionFilter", (object)region ?? DBNull.Value);
            var p3 = new SqlParameter("@FromDate", (object)fromDate ?? DBNull.Value);
            var p4 = new SqlParameter("@ToDate", (object)toDate ?? DBNull.Value);

            return this.Database
                .SqlQuery<ReportData>(
                    "EXEC dbo.sp_GetReportsForEF @CategoryFilter, @RegionFilter, @FromDate, @ToDate",
                    p1, p2, p3, p4)
                .ToList();
        }
    }


}