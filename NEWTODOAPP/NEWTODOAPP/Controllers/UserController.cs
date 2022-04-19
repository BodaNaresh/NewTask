﻿using NEWTODOAPP.Models;
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
    public class UserController : ApiController
    {

        DataTable dt = new DataTable();

        [HttpPost]
        public string PostData(Register register)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            using (SqlCommand cmd = new SqlCommand("createUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", register.Name);
                cmd.Parameters.AddWithValue("@Email", register.Email);
                cmd.Parameters.AddWithValue("@Gender", register.Gender);
                cmd.Parameters.AddWithValue("@Mobile", register.Mobile);
                cmd.Parameters.AddWithValue("@Location", register.Location);
                cmd.Parameters.AddWithValue("@Password", register.Password);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return "Inserted Successfully";
            }
        }
    }
}
