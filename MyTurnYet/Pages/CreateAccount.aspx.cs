using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTurnYet.Pages
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        private bool Emailexist = false;
        private static Random r = new Random();
        private string ID = "";

        protected void Page_Load(object sender, EventArgs e)

        {
            Confirm_Click.ServerClick += Confirm_Click_ServerClick;
        }

        private void Confirm_Click_ServerClick(object sender, EventArgs e)
        {
            //TODO
            //Skapa konto Logik

            if (epost.Value == "" || pass.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Var vänlig och fyll i alla fälten!')", true);
            }
            else
            {
                SqlConnection sql = new SqlConnection(Database.Connectionstring.con);
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [Login]";
                cmd.Connection = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[1].ToString() == epost.Value)
                    {
                        Emailexist = true;
                        break;
                    }
                }
                if (Emailexist == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Det finns redan ett konto registerat med det här e-post!')", true);
                }
                else
                {
                    var _s = ID;
                    ID = Gen();
                    SqlConnection myConnection = new SqlConnection(Database.Connectionstring.con);
                    SqlCommand myCommand = new SqlCommand(
                       "INSERT into Login (ID, Email, Pass, UType)" +
                       "VALUES (@ID, @Email, @Pass, @UType)");
                    myCommand.Parameters.AddWithValue("@ID", ID);
                    myCommand.Parameters.AddWithValue("@Email", epost.Value);
                    myCommand.Parameters.AddWithValue("@Pass", pass.Value);
                    myCommand.Parameters.AddWithValue("@UType", "U");
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    Session["ID"] = ID;
                    Response.Redirect("index.aspx?" + ID);
                }
            }
        }

        public string Gen()
        {
            char[] C = { 'A', 'B', 'C', 'D', 'E', 'F' };
            string a = "";
            for (int x = 0; x < 10; x++)
            {
                a += C[r.Next(C.Length)];
            }
            return a;
        }

        private void Clear()
        {
            epost.Value = pass.Value = "";
        }
    }
}