using MyTurnYet.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyTurnYet.Database
{
    public class DataAccesLayer
    {
        public string _FID = "";
        public string _status = "F";
        public string New_Status = "A";

        public List<SignUp_Children> GetAllChildrenwithF()
        {
            List<SignUp_Children> listChildrens = new List<SignUp_Children>();
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                SqlCommand cmd = new SqlCommand("Select ID, FName, LName, Age, Status from SignUp_Children where Status = '" + _status + "'", sql);
                sql.Open();
                SqlDataReader sqlda = cmd.ExecuteReader();
                while (sqlda.Read())
                {
                    SignUp_Children children = new SignUp_Children();
                    children.ID = sqlda["ID"].ToString();
                    children.FName = sqlda["FName"].ToString();
                    children.LName = sqlda["LName"].ToString();
                    children.Age = Convert.ToInt32(sqlda["Age"]);
                    listChildrens.Add(children);
                }
            }
            return listChildrens;
        }

        public List<SignUp_Children> GetAllChildrenwithA()
        {
            List<SignUp_Children> listChildrens = new List<SignUp_Children>();
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                SqlCommand cmd = new SqlCommand("Select ID, FName, LName, Age, Status from SignUp_Children where Status = '" + New_Status + "'", sql);
                sql.Open();
                SqlDataReader sqlda = cmd.ExecuteReader();
                while (sqlda.Read())
                {
                    SignUp_Children children = new SignUp_Children();
                    children.ID = sqlda["ID"].ToString();
                    children.FName = sqlda["FName"].ToString();
                    children.LName = sqlda["LName"].ToString();
                    children.Age = Convert.ToInt32(sqlda["Age"]);
                    listChildrens.Add(children);
                }
            }
            return listChildrens;
        }

        public List<SignUp_Children> GetChildrenByFIDandF()
        {
            List<SignUp_Children> listChildren = new List<SignUp_Children>();
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                String query = "select ID, FName, LName, Age, Status from SignUp_Children where (FID = '" + _FID + "') AND (Status = '" + _status + "');";
                SqlCommand cmd = new SqlCommand(query, sql);
                sql.Open();
                SqlDataReader sqlda = cmd.ExecuteReader();
                while (sqlda.Read())
                {
                    SignUp_Children children = new SignUp_Children();
                    children.ID = sqlda["ID"].ToString();
                    children.FName = sqlda["FName"].ToString();
                    children.LName = sqlda["LName"].ToString();
                    children.Age = Convert.ToInt32(sqlda["Age"]);
                    children.Status = sqlda["Status"].ToString();
                    listChildren.Add(children);
                }
            }
            return listChildren;
        }

        public List<SignUp_Children> GetChildrenByFIDandA()
        {
            List<SignUp_Children> listChildren = new List<SignUp_Children>();
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                String query = "select ID, FName, LName, Age, Status from SignUp_Children where (FID = '" + _FID + "') AND (Status = '" + New_Status + "');";
                SqlCommand cmd = new SqlCommand(query, sql);
                sql.Open();
                SqlDataReader sqlda = cmd.ExecuteReader();
                while (sqlda.Read())
                {
                    SignUp_Children children = new SignUp_Children();
                    children.ID = sqlda["ID"].ToString();
                    children.FName = sqlda["FName"].ToString();
                    children.LName = sqlda["LName"].ToString();
                    children.Age = Convert.ToInt32(sqlda["Age"]);
                    children.Status = sqlda["Status"].ToString();
                    listChildren.Add(children);
                }
            }
            return listChildren;
        }

        public void GetChildrenByfather()
        {
            // Get FatherCode (ID)
            using (SqlConnection sql = new SqlConnection(Database.Connectionstring.con))
            {
                UserPage pg = new UserPage();
                sql.Open();
                string FatherIDQuery = "select ID from Login where Email ='" + pg.Session["epost"] + "'";
                SqlCommand cmd = new SqlCommand(FatherIDQuery, sql);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _FID = ds.Tables[0].Rows[0]["ID"].ToString();
                    pg.Session["FatherFID"] = _FID;
                }
                if (_FID == null)
                {
                    return;
                }
            }
        }

        public void DeleteChildren(string ChildrenID)
        {
            using (SqlConnection con = new SqlConnection(Database.Connectionstring.con))
            {
                SqlCommand cmd = new SqlCommand
                    ("Delete from SignUp_Children where ID = @ID", con);
                SqlParameter param = new SqlParameter("@ID", ChildrenID);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static int UpdateChildrens(int ChildrenID, string FName, string LName, string Age)
        {
            using (SqlConnection con = new SqlConnection(Connectionstring.con))
            {
                string updateQuery = "Update SignUp_Children SET FName = @FName,  " +
                    "LName = @LName, Age = @Age WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOriginalChildrenID = new
                    SqlParameter("@ID", ChildrenID);
                cmd.Parameters.Add(paramOriginalChildrenID);
                SqlParameter paramFName = new SqlParameter("@FName", FName);
                cmd.Parameters.Add(paramFName);
                SqlParameter paramLName = new SqlParameter("@LName", LName);
                cmd.Parameters.Add(paramLName);
                SqlParameter paramAge = new SqlParameter("@Age", Age);
                cmd.Parameters.Add(paramAge);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public class SignUp_Children
    {
        public string ID { get; set; }
        public string FID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Status { get; set; }
        public int Age { get; set; }
    }
}