using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Accounts
    {
        public int code { get; set; }
        public int person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set; }
    }
}
