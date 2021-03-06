using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface ITransaction
    {
        IList<Transactions> GetTransactionsByAccountCode(int? id);
        Transactions GetTransactionByCode(int? id);
        void InsertNew(Transactions account);
        void Update(Transactions account);
        void Delete(int? id);
    }
}
