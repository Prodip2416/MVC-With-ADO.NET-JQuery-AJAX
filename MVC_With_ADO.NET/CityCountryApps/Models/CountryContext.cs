using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityCountryApp.Models
{
    public class CountryContext
    {
        public SqlConnection Con;

        public void Connection()
        {
            string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            Con= new SqlConnection(str);
        }
    }
}