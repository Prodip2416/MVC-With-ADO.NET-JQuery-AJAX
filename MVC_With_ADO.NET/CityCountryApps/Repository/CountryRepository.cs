using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CityCountryApp.Models;

namespace CityCountryApp.Repository
{
    public class CountryRepository
    {
        CountryContext countryContext= new CountryContext();
        public List<Country> GetAllCountry()
        {
            countryContext.Connection();

            List<Country> countries= new List<Country>();

            SqlCommand command= new SqlCommand("GetAllCountry", countryContext.Con);
            command.CommandType=CommandType.StoredProcedure;

            countryContext.Con.Open();

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Country country= new Country()
                {
                    Id = Convert.ToInt32(rdr["id"]),
                    Name = rdr["name"].ToString()
                };

                countries.Add(country);
            }
            countryContext.Con.Close();
            return countries;
        }

        public bool AddCountry(Country country)
        {
            countryContext.Connection();

            SqlCommand command= new SqlCommand("AddCountry",countryContext.Con);

            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", country.Name);

            countryContext.Con.Open();
            int i = command.ExecuteNonQuery();
            countryContext.Con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCountry(Country country)
        {
            countryContext.Connection();

            SqlCommand command = new SqlCommand("UpdateCountry", countryContext.Con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", country.Id);
            command.Parameters.AddWithValue("@Name", country.Name);

            countryContext.Con.Open();
            int i = command.ExecuteNonQuery();
            countryContext.Con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCountry(int id)
        {
            countryContext.Connection();

            SqlCommand command = new SqlCommand("DeleteCountry", countryContext.Con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            countryContext.Con.Open();
            int i = command.ExecuteNonQuery();
            countryContext.Con.Close();

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