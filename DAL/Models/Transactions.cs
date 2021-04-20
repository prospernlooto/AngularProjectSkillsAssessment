using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Transactions
    {
        public int code { get; set; }
        public int account_code { get; set; }
        public DateTime transaction_date { get; set; }
        public DateTime capture_date { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
    }
}
