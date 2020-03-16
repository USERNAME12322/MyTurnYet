using MyTurnYet.Database;
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
    public partial class AdminPage : System.Web.UI.Page
    {
        public string _FID = "";
        public List<SignUp_Children> children = new List<SignUp_Children>();

        public DataAccesLayer data = new DataAccesLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
            EmptyGrid();
            logut_btn.Click += Logut_btn_Click;
        }

        public void BindGridViewData()
        {
            GridView1.DataSource = data.GetAllChildren();
            Fill_Grid();
            EmptyGrid();
            GridView1.DataBind();
        }

        private void Logut_btn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        public void Fill_Grid()
        {
            children.Clear();
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
                }
                if (_FID == null)
                {
                    return;
                }
            }

            //Get Childrens_Info
            using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
            {
                sql2.Open();
                //string ChildrensInfoQuery = "select ID,FName,LName,Age from SignUp_Children where FID ='" + _FID + "'";
                string AllChildrenQuery = "select ID,FName,LName,Age from SignUp_Children";
                SqlCommand cmd2 = new SqlCommand(AllChildrenQuery, sql2);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        string _ID = ds.Tables[0].Rows[x]["ID"].ToString();
                        string _FName = ds.Tables[0].Rows[x]["FName"].ToString();
                        string _LName = ds.Tables[0].Rows[x]["LName"].ToString();
                        int _Age = (int)ds.Tables[0].Rows[x]["Age"];
                        var ch = new SignUp_Children { ID = _ID, FName = _FName, LName = _LName, Age = _Age };
                        children.Add(ch);
                    }
                }
            }
        }

        public void EmptyGrid()
        {
            using (SqlConnection sql2 = new SqlConnection(Database.Connectionstring.con))
            {
                sql2.Open();
                //string ChildrensInfoQuery = "select ID,FName,LName,Age from SignUp_Children where FID ='" + _FID + "'";
                string AllChildrenQuery = "select ID,FName,LName,Age from SignUp_Children";
                SqlCommand cmd2 = new SqlCommand(AllChildrenQuery, sql2);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel_notfound.Visible = false;
                    Panel_found.Visible = true;
                    lbl_3.Text = "Registerade Barn:";
                    lbl_4.Text = "Var vänligt och klicka på hämtats om barnet har hämtats!";
                    lbl_4.ForeColor = System.Drawing.Color.Green;
                    notfound_img.ImageUrl = "";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                data.DeleteChildren(e.CommandArgument.ToString());
                Fill_Grid();
                EmptyGrid();
                BindGridViewData();
            }
        }
    }
}