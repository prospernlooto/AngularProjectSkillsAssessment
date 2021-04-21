using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IAccount
    {
        IList<Accounts> GetAccountsByPersonCode(int? id);
        IList<Accounts> GetAllAccounts();
        Accounts GetAccountByCode(int? id);
        void InsertNew(Accounts account);
        void Update(Accounts account);
        void Delete(Accounts account);
    }
}
