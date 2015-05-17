using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem.Domain
{
    public class Account 
    {
        public int AccountId { get; set; }

        public int UserId { get; set; }

        public string AccountNo { get; set; }

        public string Pin { get; set; }

        public decimal AccountBalance { get; set; }

        public bool AccountStatus { get; set; }

        public bool AcccountDelete { get; set; }
    }
}
