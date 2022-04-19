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
    public class UpdateController : ApiController
    {
        DataTable dt = new DataTable();

        
        [HttpPut]
        public string UpdateStatus(Todo todo, int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("UpdateTodoStatus ", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TodoId", id);
                cmd.Parameters.AddWithValue("@Status", todo.Status);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return "Updated Successfully";
        }
    }
}