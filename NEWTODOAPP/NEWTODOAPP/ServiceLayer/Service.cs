using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWTODOAPP.Models
{
    
    public class Service
    {
        DataAccess data = new DataAccess();
        public string Register(Register reg)
        {
            return data.Register(reg);
        }
        public string Login(Login log)
        {
            return data.Login(log);
        }

      

    }
}