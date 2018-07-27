using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FullCRUDWithJquery.Models
{
    public class StudentDB
    {
        string cs = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public List<Student> GetAllStudent()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Student> students= new List<Student>();

                SqlCommand command= new SqlCommand("GetAllStudent", con);
                command.CommandType=CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student()
                    {
                        StudentId = Convert.ToInt32(rdr["StudentId"]),
                        Name = rdr["Name"].ToString(),
                        Email=rdr["Email"].ToString()
                    };

                    Department department=new Department()
                    {
                       DepartmentName=rdr["DepartmentName"].ToString()
                    };

                    student.Department = department;

                    students.Add(student);
                }
                con.Close();
                return students;
            }
        }

        public bool AddStudent(Student student)
        {
            using (SqlConnection con= new SqlConnection(cs))
            {
                SqlCommand command= new SqlCommand("AddStudent", con);
                command.CommandType=CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);

                con.Open();
                int i = command.ExecuteNonQuery();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("UpdateStudent", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", student.StudentId);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);

                con.Open();
                int i = command.ExecuteNonQuery();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command= new SqlCommand("DeleteStudent", con);
                command.CommandType=CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                con.Open();
                int i = command.ExecuteNonQuery();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}