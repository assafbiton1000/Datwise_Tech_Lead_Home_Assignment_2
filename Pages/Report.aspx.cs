using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class Report : Page
    {
        protected int CurrentPage
        {
            get { return ViewState["CurrentPage"] == null ? 1 : (int)ViewState["CurrentPage"]; }
            set { ViewState["CurrentPage"] = value; }
        }

        protected string CurrentSortExpression
        {
            get { return ViewState["SortExpr"] == null ? "EventDate" : ViewState["SortExpr"].ToString(); }
            set { ViewState["SortExpr"] = value; }
        }

        protected string CurrentSortDir
        {
            get { return ViewState["SortDir"] == null ? "DESC" : ViewState["SortDir"].ToString(); }
            set { ViewState["SortDir"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFilters();
                BindGrid();
            }
        }

        private void PopulateFilters()
        {
            DataTable dtCat = DbHelper.ExecuteDataTable("SELECT DISTINCT Category FROM dbo.ReportsData ORDER BY Category");
            foreach (DataRow r in dtCat.Rows)
            {
                ddlCategory.Items.Add(new ListItem(r["Category"].ToString(), r["Category"].ToString()));
            }

            DataTable dtReg = DbHelper.ExecuteDataTable("SELECT DISTINCT Region FROM dbo.ReportsData ORDER BY Region");
            foreach (DataRow r in dtReg.Rows)
            {
                ddlRegion.Items.Add(new ListItem(r["Region"].ToString(), r["Region"].ToString()));
            }
        }

        protected void FilterChanged(object sender, EventArgs e)
        {
            CurrentPage = 1;
            BindGrid();
        }

        private void BindGrid()
        {
            int pageSize = gvReport.PageSize;
            int pageNumber = CurrentPage;

            SqlParameter[] parms = new SqlParameter[] {
            new SqlParameter("@PageNumber", pageNumber),
            new SqlParameter("@PageSize", pageSize),
            new SqlParameter("@CategoryFilter", string.IsNullOrEmpty(ddlCategory.SelectedValue) ? (object)DBNull.Value : ddlCategory.SelectedValue),
            new SqlParameter("@RegionFilter", string.IsNullOrEmpty(ddlRegion.SelectedValue) ? (object)DBNull.Value : ddlRegion.SelectedValue),
            new SqlParameter("@FromDate", DBNull.Value),
            new SqlParameter("@ToDate", DBNull.Value)
        };

            // Call stored proc - it returns rows first, then TotalCount as a second result set
            DataSet ds = new DataSet();
            using (var conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new System.Data.SqlClient.SqlCommand("dbo.sp_GetReportPaged", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parms);
                using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }

            DataTable dtRows = ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
            DataTable dtCount = ds.Tables.Count > 1 ? ds.Tables[1] : null;
            int totalCount = dtCount != null && dtCount.Rows.Count > 0 ? Convert.ToInt32(dtCount.Rows[0]["TotalCount"]) : dtRows.Rows.Count;

            gvReport.DataSource = dtRows;
            gvReport.DataBind();

            // simple pager - set PageIndex via GridView built-in paging
            // We keep CurrentPage state in ViewState as offset for stored proc
        }

        protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CurrentPage = e.NewPageIndex + 1;
            BindGrid();
        }

        protected void gvReport_Sorting(object sender, GridViewSortEventArgs e)
        {
            // basic: toggle sort direction
            if (CurrentSortExpression == e.SortExpression)
                CurrentSortDir = (CurrentSortDir == "ASC") ? "DESC" : "ASC";
            else
            {
                CurrentSortExpression = e.SortExpression;
                CurrentSortDir = "ASC";
            }
            // Note: Stored procedure currently orders by EventDate; for advanced sorting add dynamic ORDER BY
            BindGrid();
        }

        protected void btnExportCsv_Click(object sender, EventArgs e)
        {
            // Export current filter results to CSV (all rows matching filters)
            string sql = "SELECT Id, Category, Region, ValueAmount, EventDate FROM dbo.ReportsData WHERE 1=1";
            List<SqlParameter> pars = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                sql += " AND Category = @cat";
                pars.Add(new SqlParameter("@cat", ddlCategory.SelectedValue));
            }
            if (!string.IsNullOrEmpty(ddlRegion.SelectedValue))
            {
                sql += " AND Region = @reg";
                pars.Add(new SqlParameter("@reg", ddlRegion.SelectedValue));
            }
            sql += " ORDER BY EventDate DESC";

            DataTable dt = DbHelper.ExecuteDataTable(sql, pars.ToArray());
            StringBuilder sb = new StringBuilder();

            // header
            sb.AppendLine("Id,Category,Region,ValueAmount,EventDate");

            foreach (DataRow r in dt.Rows)
            {
                sb.AppendFormat("{0},{1},{2},{3},{4}",
                    r["Id"],
                    EscapeCsv(r["Category"].ToString()),
                    EscapeCsv(r["Region"].ToString()),
                    r["ValueAmount"],
                    Convert.ToDateTime(r["EventDate"]).ToString("yyyy-MM-dd")
                );
                sb.AppendLine();
            }

            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=report_export.csv");
            Response.Write(sb.ToString());
            Response.End();
        }

        private string EscapeCsv(string s)
        {
            if (s == null) return "";
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
            {
                s = s.Replace("\"", "\"\"");
                return "\"" + s + "\"";
            }
            return s;
        }
    }
}