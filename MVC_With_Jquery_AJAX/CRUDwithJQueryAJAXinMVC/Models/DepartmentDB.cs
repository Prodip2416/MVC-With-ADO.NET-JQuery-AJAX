using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FullCRUDWithJquery.Models
{
    public class DepartmentDB
    {
        private string cs = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        public List<Department> GetAllStudent()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Department> departments = new List<Department>();

                SqlCommand command = new SqlCommand("getDepartment", con);
                command.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Department department = new Department()
                    {
                        DepartmentId =Convert.ToInt32(rdr["DepartmentId"]),
                        DepartmentName = rdr["DepartmentName"].ToString()
                    };

                  

                    departments.Add(department);
                }
                con.Close();
                return departments;
            }
        }
    }
}