using Datwise_Tech_Lead_Home_Assignment.Models;
using System;
using System.Data.Entity.Validation;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUsers_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUsers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        /// <summary>
        /// gvUsers_RowUpdating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string PasswordHash = txtPasswordHash.Text.Trim();
            string role = txtRole.Text.Trim();
            bool isActive = chkIsActive.Checked;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "נא למלא את כל השדות";
                lblMessage.CssClass = "text-danger";
                return;
            }

            try
            {
                using (var db = new DatwiseDBEntities())
                {
                    var newUser = new Datwise_Tech_Lead_Home_Assignment.Users
                    {
                        Username = username,
                        Email = Email,
                        FullName = username,
                        PasswordHash = PasswordHash,
                        Role = role,
                        IsActive = isActive
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // ניקוי השדות
                    txtUsername.Text = "";
                    txtEmail.Text = "";
                    txtPasswordHash.Text = "";
                    txtFullName.Text = "";
                    txtRole.Text = "";
                    chkIsActive.Checked = false;

                    // ריענון הגריד
                    LoadUsers();

                    lblMessage.Text = "המשתמש נוסף בהצלחה!";
                    lblMessage.CssClass = "text-success";
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Response.Write($"<p>שדה: {ve.PropertyName} — שגיאה: {ve.ErrorMessage}</p>");
                        lblMessage.Text = "קיימת שגיאה באחד מהשדות";
                        lblMessage.CssClass = "text-success";
                    }
                }
            }



        }
    }
}