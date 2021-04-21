using DAL.Helpers;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PersonService : IPerson
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public void Delete(Persons person)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_DeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@code", person.code);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Persons> GetPersons()
        {
            List<Persons> personsList = new List<Persons>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetAllPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var personModel = new Persons()
                    {
                        code = DataTypesConvertor.ConvertToInt(rdr["code"]),
                        name = rdr["name"].ToString(),
                        surname = rdr["surname"].ToString(),
                        id_number = rdr["id_number"].ToString()
                    };
                    personsList.Add(personModel);
                }
                return (personsList);
            }
        }

        public Persons GetPersonsById(int? id)
        {
            Persons personModel = new Persons();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetPersonByCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    personModel.code = DataTypesConvertor.ConvertToInt(rdr["code"]);
                    personModel.name = rdr["name"].ToString();
                    personModel.surname = rdr["surname"].ToString();
                    personModel.id_number = rdr["id_number"].ToString();
                }
                return personModel;
            }
        }

        public void InsertNew(Persons person)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_AddPerson", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", person.name);
                cmd.Parameters.AddWithValue("@surname", person.surname);
                cmd.Parameters.AddWithValue("@id_number", person.id_number);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Persons> SearchPersons(string term)
        {
            List<Persons> personsList = new List<Persons>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_SearchPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@term", term);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var personModel = new Persons()
                    {
                        code = DataTypesConvertor.ConvertToInt(rdr["code"]),
                        name = rdr["name"].ToString(),
                        surname = rdr["surname"].ToString(),
                        id_number = rdr["id_number"].ToString()
                    };
                    personsList.Add(personModel);
                }
                return (personsList);
            }
        }


        public void Update(Persons person)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_UpdatePerson", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", person.code);
                cmd.Parameters.AddWithValue("@name", person.name);
                cmd.Parameters.AddWithValue("@surname", person.surname);
                cmd.Parameters.AddWithValue("@id_number", person.id_number);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
