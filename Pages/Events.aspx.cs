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
                LoadPieData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadChartData()
        {
            using (var db = new DatwiseContext())
            {
                var data = db.GetReportsForCharts()
                             .OrderBy(x => x.Id)
                             .ToList();

                Chart1.Series["SalesSeries"].Points.Clear();
                foreach (var item in data)
                {
                    Chart1.Series["SalesSeries"].Points.AddXY(item.Region, item.ValueAmount);
                }
            }
        }

        private void LoadPieData()
        {
            using (var db = new DatwiseContext())
            {
                var data = db.GetReportsForCharts().ToList();

                var grouped = data.GroupBy(x => x.Category)
                                  .Select(g => new { Category = g.Key, Count = g.Count() });

                Chart2.Series["Categories"].Points.Clear();
                foreach (var item in grouped)
                {
                    Chart2.Series["Categories"].Points.AddXY(item.Category, item.Count);
                }
            }
        }
    }
}
