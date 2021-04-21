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
    public class TransactionService : ITransaction
    {

        private readonly string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_DeleteTransactionsByAccountCode", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_code", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Transactions GetTransactionByCode(int? id)
        {
            Transactions accountModel = new Transactions();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetTransactionByCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    accountModel.code = DataTypesConvertor.ConvertToInt(rdr["code"]);
                    accountModel.account_code = DataTypesConvertor.ConvertToInt(rdr["person_code"]);
                    accountModel.transaction_date = DataTypesConvertor.ConvertToDateTime(rdr["transaction_date"]);
                    accountModel.capture_date = DataTypesConvertor.ConvertToDateTime(rdr["capture_date"]);
                    accountModel.amount = DataTypesConvertor.ConvertToDecimal(rdr["amount"]);
                    accountModel.description = rdr["description"].ToString();
                }
                return accountModel;
            }
        }

        public IList<Transactions> GetTransactionsByAccountCode(int? id)
        {
            List<Transactions> transactionList = new List<Transactions>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("pr_GetTransactionsByAccountCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_code", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                var transactionModel = new Transactions()
                {
                   code = DataTypesConvertor.ConvertToInt(rdr["code"]),
                   account_code = DataTypesConvertor.ConvertToInt(rdr["account_code"]),
                   transaction_date = DataTypesConvertor.ConvertToDateTime(rdr["transaction_date"]),
                   capture_date = DataTypesConvertor.ConvertToDateTime(rdr["capture_date"]),
                   amount = DataTypesConvertor.ConvertToDecimal(rdr["amount"]),
                   description = rdr["description"].ToString()
                };
                    transactionList.Add(transactionModel);
                }
                return (transactionList);
            }
        }

        public void InsertNew(Transactions transaction)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_AddNewTransaction", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_code", transaction.account_code);
                cmd.Parameters.AddWithValue("@transaction_date", transaction.transaction_date);
                cmd.Parameters.AddWithValue("@amount", transaction.amount);
                cmd.Parameters.AddWithValue("@description", transaction.description);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Transactions transaction)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("pr_UpdateTransaction", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", transaction.code);
                cmd.Parameters.AddWithValue("@account_code", transaction.account_code);
                cmd.Parameters.AddWithValue("@transaction_date", transaction.transaction_date);
                cmd.Parameters.AddWithValue("@amount", transaction.amount);
                cmd.Parameters.AddWithValue("@description", transaction.description);
                cmd.ExecuteNonQuery();
            }
        }

        public void Validate(Transactions model)
        {
            if (!string.IsNullOrEmpty(model.description))
            {
                model.description = model.description.ToLower();
            }

            if (model.transaction_date > DateTime.Now)
            {
                throw new Exception("The transaction date can never be in the future");
               
            }

            if (model.amount == 0)
            {
                throw new Exception("The transaction amount can never be zero ");
            }

            if (model.description != "debit" && model.description != "credit")
            {
                throw new Exception("The description must be debit or credit.");
            }
        }
    }
}
