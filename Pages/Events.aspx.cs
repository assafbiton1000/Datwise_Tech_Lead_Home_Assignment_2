using Datwise_Tech_Lead_Home_Assignment.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChartData();
            }
        }

        private void LoadChartData()
        {
            using (var db = new DatwiseContext())
            {
                var data = db.GetPagedReports(1, 100, null, null, null, null).ToList().OrderBy(x => x.Id);



                Chart1.Series["SalesSeries"].Points.Clear();

                foreach (var item in data)
                {
                    Chart1.Series["SalesSeries"].Points.AddXY(item.Region, item.ValueAmount);
                }
            }
        }
    }
}