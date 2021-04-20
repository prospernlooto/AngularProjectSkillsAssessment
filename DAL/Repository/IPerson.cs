using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPerson
    {
        IList<Persons> GetPersons();
        IList<Persons> SearchPersons(string term);
        Persons GetPersonsById(int? id);
        void InsertNew(Persons employee);
        void Update(Persons employee);
        void Delete(Persons employee);
    }
}
