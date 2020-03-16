using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace MyTurnYet.Pages
{
    public partial class index : System.Web.UI.Page
    {
        private string _FID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                _FID = Session["ID"].ToString();
            }
            Crt_Btn.ServerClick += Crt_Btn_ServerClick;
            LogIn_Btn.ServerClick += LogIn_Btn_ServerClick;
        }

        private void LogIn_Btn_ServerClick(object sender, EventArgs e)
        {
            //Login Logik

            string Epost = epost.Value;
            string Password = pass.Value;
            string both = Epost + Password;
            SqlConnection connection = new SqlConnection(Database.Connectionstring.con);
            connection.Open();
            //string passwords = EncryptPassword(Password);
            String query = "SELECT Email,Pass,UType FROM Login WHERE (Email = '" + Epost + "') AND (Pass = '" + Password + "');";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sds = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sds.SelectCommand = cmd;
            int i = 0;
            sds.Fill(ds, "Password");
            if (ds.Tables[i].Rows.Count > 0)
            {
                if (ds.Tables[i].Rows[i]["UType"].ToString() == "A")
                {
                    // If you login and you are admin
                    Session["epost"] = epost.Value;
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    // If you log in and you are not Admin
                    Session["epost"] = epost.Value;
                    var saved = Session["epost"] + _FID;
                    Response.Redirect("UserPage.aspx?" + saved);
                }
            }
            else if (both == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Var vänlig och fyll i alla fälten!')", true);

                clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Du har angett fel Användarnamn eller Lösenord!')", true);
            }
            connection.Close();
        }

        private void clear()
        {
            epost.Value = pass.Value = "";
        }

        private void Crt_Btn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        //Enkrypt Password
        public string EncryptPassword(string pass)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(pass);
            string enkryptedpassword = Convert.ToBase64String(bytes);
            return enkryptedpassword;
        }

        //Dekrypt Password
        public string dekryptPassword(string pass)
        {
            byte[] bytes = Convert.FromBase64String(pass);
            string dekryptpassword = System.Text.Encoding.Unicode.GetString(bytes);
            return dekryptpassword;
        }

        private void Get_father_Code()
        {
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                sql.Open();
                string Fathercodecommand = "select ID from Login where Email ='" + Session["epost"] + "'";
                SqlCommand cmd2 = new SqlCommand(Fathercodecommand, sql);
                //cmd2.CommandText = Fathercodecommand;
                //cmd2.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _FID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (_FID == null)
                {
                    return;
                }
            }
        }
    }
}