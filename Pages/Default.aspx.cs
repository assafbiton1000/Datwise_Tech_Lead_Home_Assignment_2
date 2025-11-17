using System;
using System.Data;
using System.Web.UI;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblWelcome.Text =
                    "שלום, " + (User.Identity.IsAuthenticated ? User.Identity.Name : "אורח");
                LoadKPIs();
            }
        }

        private void LoadKPIs()
        {
            DataTable dt = DbHelper.ExecuteDataTable(
                @"
            SELECT COUNT(1) AS TotalCount, SUM(ValueAmount) AS TotalSum 
            FROM dbo.ReportsData
        "
            );

            if (dt.Rows.Count > 0)
            {
                lblTotal.Text = dt.Rows[0]["TotalCount"].ToString();
                lblSum.Text =
                    dt.Rows[0]["TotalSum"] != DBNull.Value
                        ? string.Format("{0:N2}", dt.Rows[0]["TotalSum"])
                        : "0.00";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}
