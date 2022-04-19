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
    public class AdminApiController : ApiController
    {
        DataTable dt = new DataTable();

        [HttpGet]
        
        public DataTable GetAllTodos()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("GetTodo", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
                
            return dt;
        }

        [HttpPost]
        public string PostToDo(Todo list)
        {
           
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("CreateTodo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", list.Title);
                cmd.Parameters.AddWithValue("@Status", list.Status);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return "Inserted Successfully";
            }
        }
    
        [HttpDelete]
        public string DeleteToDo(int id)
        {
           
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("DeleteTodo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TodoId", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return "Deleted Successfully";
            }
        }


        [HttpPut]
        public string UpdateToDo(Todo todo, int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("UpdateTodo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TodoId", id);
                cmd.Parameters.AddWithValue("@Title", todo.Title);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return "Updated Successfully";
        }
    }



}

