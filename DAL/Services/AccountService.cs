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
    public class AccountService : IAccount
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public void Delete(Accounts person)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_DeleteAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", person.code);
                con.Open();
              
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Accounts> GetAccountsByPersonCode(int? id)
        {
            List<Accounts> accountList = new List<Accounts>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetAccountsByPersonCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@person_code", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var accountModel = new Accounts()
                    {
                        code = Convert.ToInt32(rdr["code"]),
                        person_code = Convert.ToInt32(rdr["person_code"]),
                        account_number = rdr["account_number"].ToString(),
                        outstanding_balance = Convert.ToDecimal(rdr["outstanding_balance"])
                    };
                    accountList.Add(accountModel);
                }
                return (accountList);
            }
        }

        public Accounts GetAccountByCode(int? id)
        {
            Accounts accountModel = new Accounts();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetPersonByCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    accountModel.code = Convert.ToInt32(rdr["code"]);
                    accountModel.person_code = Convert.ToInt32(rdr["person_code"]);
                    accountModel.account_number = rdr["account_number"].ToString();
                    accountModel.outstanding_balance = Convert.ToDecimal(rdr["outstanding_balance"]);
                }
                return accountModel;
            }
        }

        public void InsertNew(Accounts employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_AddNewAccount", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@person_code", employee.person_code);
                cmd.Parameters.AddWithValue("@account_number", employee.account_number);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Accounts employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_UpdateAccount", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", employee.code);
                cmd.Parameters.AddWithValue("@account_number", employee.account_number);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
