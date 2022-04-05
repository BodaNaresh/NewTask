using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace NEWTODOAPP.Models
{
    public class DataAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter dad = null;
        DataTable dt = null;
        public string Register(Register register)
        {

            cmd = new SqlCommand("insert into Registration(UserName,Email,Gender,Mobile,Location,Password)values('" + register.UserName + "','" + register.Email + "','" + register.Gender + "','" + register.Mobile + "','" + register.Location + "','" + register.Password + "')", con) ;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return "Sucessfully Registred";
            }
            else
            {
                return "Registration failed";
            }

        }

        public string Login(Login login)
        {
            dad = new SqlDataAdapter("select * from Registration where Email='" + login.Email+"' AND Password='"+login.Password+"'", con);
            dt = new DataTable();
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return "Logged in";
            }
            else
            {
                return "Login Failed";
            }
        }

      
    }
}