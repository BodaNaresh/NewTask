using NEWTODOAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NEWTODOAPP.Controllers
{
    public class LoginController : ApiController
    {
        DataTable dt = new DataTable();

        [HttpPost]

        public DataTable GetCredentials(Register login)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("Users", con))
            {
                cmd.Parameters.AddWithValue("@Email", login.Email);
                cmd.Parameters.AddWithValue("@Password", login.Password);

                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
