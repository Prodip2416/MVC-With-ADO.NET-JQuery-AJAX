using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CityCountryApp.Models;

namespace CityCountryApp.Repository
{
    public class CityRepository
    {
        CountryContext countryContext= new CountryContext();
        public List<City> GetAllCityDetails()
        {
            countryContext.Connection();

            List<City> cities = new List<City>();

            SqlCommand command = new SqlCommand("GetAllCityDetails", countryContext.Con);
            command.CommandType = CommandType.StoredProcedure;

            countryContext.Con.Open();

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                City city = new City()
                {
                    Id = Convert.ToInt32(rdr["id"]),
                    Name = rdr["name"].ToString(),
                    //CountryId = Convert.ToInt32(rdr["countryId"])
                };
                Country country= new Country()
                {
                    Id=Convert.ToInt32(rdr["id"]),
                    Name = rdr["countryName"].ToString()
                };

                city.Country = country;

                cities.Add(city);
            }
            countryContext.Con.Close();

            return cities;
        }

        public int GetCountryId(int id)
        {
            countryContext.Connection();
            SqlCommand command= new SqlCommand("GetCountryIdByCitys", countryContext.Con);
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id",id);

            countryContext.Con.Open();
            int result = 0;
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                result = Convert.ToInt32(rdr["id"]);
            }
            return result;
        }

        public bool AddCity(City city)
        {
            countryContext.Connection();

            SqlCommand command = new SqlCommand("AddCity", countryContext.Con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", city.Name);
            command.Parameters.AddWithValue("@CountryId", city.CountryId);

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
        public bool UpdateCity(City city)
        {
            countryContext.Connection();

            SqlCommand command = new SqlCommand("UpdateCity", countryContext.Con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", city.Id);
            command.Parameters.AddWithValue("@Name", city.Name);
            command.Parameters.AddWithValue("@CountryId", city.CountryId);

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
        public bool DeleteCity(int id)
        {
            countryContext.Connection();

            SqlCommand command = new SqlCommand("DeleteCity", countryContext.Con);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id",id);

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