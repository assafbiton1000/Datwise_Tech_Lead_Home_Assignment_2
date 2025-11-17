using Datwise_Tech_Lead_Home_Assignment.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadUsers();
        }

        private void LoadUsers()
        {
            using (var db = new DatwiseContext())
            {
                gvUsers.DataSource = db.Users.ToList();
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void gvUsers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void gvUsers_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = (int)e.Keys["UserId"];

            GridViewRow row = gvUsers.Rows[e.RowIndex];
            string Username = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            string fullName = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;
            string role = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text;
            bool isActive = ((System.Web.UI.WebControls.CheckBox)row.Cells[4].Controls[0]).Checked;

            using (var db = new DatwiseContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == id);

                if (user != null)
                {
                    user.Username = Username;
                    user.FullName = fullName;
                    user.Role = role;
                    user.IsActive = isActive;

                    db.SaveChanges();
                }
            }

            gvUsers.EditIndex = -1;
            LoadUsers();

            lblMessage.Text = "השינויים נשמרו בהצלחה";
        }
    }
}