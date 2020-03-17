using MyTurnYet.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace MyTurnYet.Pages
{
    public partial class UserPage : System.Web.UI.Page
    {
        public string Test;
        private bool NameExist = false;
        private static Random r = new Random();
        private string ID = "";
        public string _FID = "";
        public string _status = "F";
        public string New_Status = "A";

        public CreateAccount createAccount = new CreateAccount();
        public DataAccesLayer dataAcces = new DataAccesLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData_F();
                BindGridViewData_A();
                if (Session["epost"] == null)
                {
                    Response.Redirect("index.aspx");
                    return;
                }
                Fill_Grid();
                EmptyGrid_F();
                EmptyGrid_A();
            }
            Confirm_Click.ServerClick += Add_Children_Cliked;
        }

        public void Add_Children_Cliked(object sender, EventArgs e)
        {
            if (Fname.Value == "" || Lname.Value == "" || age.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Var vänlig och fyll i alla fälten!')", true);
            }
            else
            {
                SqlConnection sql = new SqlConnection(Database.Connectionstring.con);
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [SignUp_Children]";
                cmd.Connection = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[2].ToString() == Fname.Value)
                    {
                        NameExist = true;
                        break;
                    }
                }
                if (NameExist == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Det finns redan ett barn registerad med det här namnet!')", true);
                }
                else
                {
                    using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
                    {
                        var _s = ID;
                        ID = createAccount.Gen();
                        Fill_Grid();
                        SqlConnection myConnection = new SqlConnection(Database.Connectionstring.con);
                        string Add_query = "INSERT into SignUp_Children(ID, FID, FName, LName, Age, Status)" + "VALUES (@ID,@FID, @FName, @LName, @Age, @Status)";
                        SqlCommand myCommand = new SqlCommand(Add_query, sql2);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@FID", _FID);
                        myCommand.Parameters.AddWithValue("@FName", Fname.Value);
                        myCommand.Parameters.AddWithValue("@LName", Lname.Value);
                        myCommand.Parameters.AddWithValue("@Age", age.Value);
                        myCommand.Parameters.AddWithValue("@Status", "F");
                        myConnection.Open();
                        myCommand.Connection = myConnection;
                        myCommand.ExecuteNonQuery();
                        //Clear();
                        myConnection.Close();
                        Clear();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Barnet har lagts till!')", true);
                        Fill_Grid();
                        EmptyGrid_F();
                        EmptyGrid_A();
                        BindGridViewData_F();
                        BindGridViewData_A();
                    }
                }
            }
        }

        //TODO
        // kunna redigera registerade barn samt refresha gridviewn när den är tom eller när man tar bort ett barn!!
        public void Fill_Grid()
        {
            // Get FatherCode (ID)
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                sql.Open();
                string FatherIDQuery = "select ID from Login where Email ='" + Session["epost"] + "'";
                SqlCommand cmd = new SqlCommand(FatherIDQuery, sql);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _FID = ds.Tables[0].Rows[0]["ID"].ToString();
                    Session["FatherFID"] = _FID;
                }
                if (_FID == null)
                {
                    return;
                }
            }

            //Get Childrens_Info

            #region GetChildrenInfo

            //Get Childrens_Info
            //using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
            //{
            //    sql2.Open();
            //    string ChildrensInfoQuery = "select ID,FName,LName,Age from SignUp_Children where FID ='" + _FID + "'";
            //    SqlCommand cmd2 = new SqlCommand(ChildrensInfoQuery, sql2);
            //    SqlDataAdapter sqlda = new SqlDataAdapter();
            //    sqlda.SelectCommand = cmd2;
            //    DataSet ds = new DataSet();
            //    sqlda.Fill(ds);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            //        {
            //            string _ID = ds.Tables[0].Rows[x]["ID"].ToString();
            //            string _FName = ds.Tables[0].Rows[x]["FName"].ToString();
            //            string _LName = ds.Tables[0].Rows[x]["LName"].ToString();
            //            int _Age = (int)ds.Tables[0].Rows[x]["Age"];
            //            var ch = new SignUp_Children { FID = _FID, ID = _ID, FName = _FName, LName = _LName, Age = _Age };
            //            children.Add(ch);
            //        }
            //    }

            //    //sql2.Open();
            //    //string ChildrensInfoQuery = "select ID,FName,LName,Age from SignUp_Children where FID ='" + _FID + "'";
            //    //SqlCommand cmd2 = new SqlCommand(ChildrensInfoQuery, sql2);
            //    //cmd2.ExecuteNonQuery();
            //    //DataTable dt = new DataTable();
            //    //SqlDataAdapter sqlData = new SqlDataAdapter(cmd2);
            //    //sqlData.Fill(dt);

            //    //if (dt.[0].Rows.Count > 0)
            //    //{
            //    //    _FID = ds.Tables[0].Rows[0]["ID"].ToString();
            //    //}
            //    //if (_FID == null)
            //    //{
            //    //    return;
            //    //}
            //    //var ch = new SignUp_Children { Age = };
            //    //children.Add
            //    ////Fill the gridView:
            //    ////Show_Children.DataSource = dt;
            //    ////Show_Children.DataBind();
            //}

            #endregion GetChildrenInfo
        }

        public void EmptyGrid_F()
        {
            using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
            {
                sql2.Open();
                String query = "select ID, FName, LName, Age, Status from SignUp_Children where (FID = '" + _FID + "') AND (Status = '" + _status + "');";
                //string AllChildrenQuery = "select ID,FName,LName,Age from SignUp_Children";
                SqlCommand cmd2 = new SqlCommand(query, sql2);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel_notfound.Visible = false;
                    Panel_found.Visible = true;
                    lbl_3.Text = "Dina registerade Barn:";
                    //lbl_4.Text = "Var vänligt och klicka på ta bort om barnet har hämtats!";
                    //lbl_4.ForeColor = System.Drawing.Color.Green;
                    notfound_img.ImageUrl = "";
                    BindGridViewData_F();
                    return;
                }
                else
                {
                    Panel_found.Visible = false;
                    Panel_notfound.Visible = true;
                    lbl_1.Text = "Det finns inga registerade Barn Just nu!";
                    lbl_1.ForeColor = System.Drawing.Color.Red;
                    lbl_2.Text = "";
                    notfound_img.ImageUrl = "../nodata.png";
                }
            }
        }

        public void EmptyGrid_A()
        {
            using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
            {
                sql2.Open();
                String query = "select ID, FName, LName, Age, Status from SignUp_Children where (FID = '" + _FID + "') AND (Status = '" + New_Status + "');";
                //string AllChildrenQuery = "select ID,FName,LName,Age from SignUp_Children";
                SqlCommand cmd2 = new SqlCommand(query, sql2);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panal_A_Not_Found.Visible = false;
                    Panal_A_Found.Visible = true;
                    Label3.Text = "Dina Inlämnade Barn:";
                    //lbl_4.Text = "Var vänligt och klicka på ta bort om barnet har hämtats!";
                    //lbl_4.ForeColor = System.Drawing.Color.Green;
                    Image1.ImageUrl = "";
                    BindGridViewData_A();
                    return;
                }
                else
                {
                    Panal_A_Found.Visible = false;
                    Panal_A_Not_Found.Visible = true;
                    Label1.Text = "Det finns inga Inlämnade Barn Just nu!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "";
                    Image1.ImageUrl = "../nodata.png";
                }
            }
        }

        public void BindGridViewData_F()
        {
            dataAcces.GetChildrenByfather();
            GridView1.DataSource = dataAcces.GetChildrenByFIDandF();
            GridView1.DataBind();
        }

        public void BindGridViewData_A()
        {
            dataAcces.GetChildrenByfather();
            GridView2.DataSource = dataAcces.GetChildrenByFIDandA();
            GridView2.DataBind();
        }

        private void Clear()
        {
            Fname.Value = Lname.Value = age.Value = "";
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                dataAcces.DeleteChildren(e.CommandArgument.ToString());
                Fill_Grid();
                EmptyGrid_F();
                BindGridViewData_F();
            }
        }

        protected void logut_btn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}