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
        Accounts GetAccountByCode(int? id);
        void InsertNew(Accounts employee);
        void Update(Accounts employee);
        void Delete(Accounts employee);
    }
}
