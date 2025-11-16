using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Security;
using System.Web.UI;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Allow anonymous access to this page
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMsg.Text = "נא למלא שם משתמש וסיסמה.";
                return;
            }

            // Hash password the same way as seed (SHA2_256)
            byte[] passHash = System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] dbHash = null;



            DataTable dt = DbHelper.ExecuteDataTable("SELECT PasswordHash, FullName, Role, IsActive FROM dbo.Users WHERE Email = @Email",
                new SqlParameter("@Email", email));
            if (dt.Rows.Count == 0)
            {
                lblMsg.Text = "שם משתמש או סיסמה שגויים.";
                return;
            }

            var row = dt.Rows[0];
            // PasswordHash column stored as varbinary; when read, may be byte[] or similar
            object phObj = row["PasswordHash"];
            if (phObj is byte[])
                dbHash = (byte[])phObj;
            else
                dbHash = Encoding.UTF8.GetBytes(phObj.ToString());

            bool ok = false;
            if (dbHash != null)
            {
                ok = CompareHashes(dbHash, passHash);
            }

            if (!ok || !(bool)row["IsActive"])
            {
                lblMsg.Text = "שם משתמש או סיסמה שגויים / משתמש לא פעיל.";
                return;
            }

            // Successful login - create forms auth ticket
            FormsAuthentication.SetAuthCookie(email, false);

            // Log audit
            DbHelper.ExecuteNonQuery("INSERT INTO dbo.AuditLog (UserEmail, Action) VALUES (@e, @a)",
                new SqlParameter("@e", email),
                new SqlParameter("@a", "Login"));

            Response.Redirect("~/Pages/Default.aspx");
        }

        private bool CompareHashes(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}