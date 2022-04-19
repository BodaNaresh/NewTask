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


        //public string Register(Register register)
        //{

        //    cmd = new SqlCommand("createUser", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Name", register.Name);
        //    cmd.Parameters.AddWithValue("@Email", register.Email);
        //    cmd.Parameters.AddWithValue("@Gender", register.Gender);
        //    cmd.Parameters.AddWithValue("@Mobile", register.Mobile);
        //    cmd.Parameters.AddWithValue("@Location", register.Location);
        //    cmd.Parameters.AddWithValue("@Password", register.Password);


        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();

        //    con.Close();
        //    if (i > 0)
        //    {
        //        return "Sucessfully Registred";
        //    }
        //    else
        //    {
        //        return "Registration failed";
        //    }

        //}

        //public string Login(Register rgg)
        //{

        //    cmd = new SqlCommand("Users", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Email", rgg.Email);
        //    cmd.Parameters.AddWithValue("Password", rgg.Password);
        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    if (i > 0)
        //    {
        //        return "Sucessfully Registred";
        //    }
        //    else
        //    {
        //        return "Registration failed";
        //    }

        //}
        //public string Todo(Todo todo)
        //{
        //    cmd = new SqlCommand("insert into Todo(Title)values('" + todo.Title + "')", con);
        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    if (i > 0)
        //    {
        //        return "Sucessfully posted";
        //    }
        //    else
        //    {
        //        return "failed";
        //    }
        //}


        //public string GetTodo(Todo todo)
        //{
        //    cmd = new SqlCommand("select * from Todo where title='"+todo.Title+"'" , con);
        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    if (i > 0)
        //    {
        //        return "Sucessfully Deleted";
        //    }
        //    else
        //    {
        //        return "failed";
        //    }

        //}


    }
}