using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PP
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Company"].ToString();

            SqlConnection conn = new SqlConnection(connStr);



            SqlCommand emp = new SqlCommand("allEmp", conn);
            emp.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = emp.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String empName = rdr.GetString(rdr.GetOrdinal("first_name"));
                Label name = new Label();
                name.Text = empName;
                form1.Controls.Add(name);
            }
            Response.Write(Session["user"]);
        }
    }
}