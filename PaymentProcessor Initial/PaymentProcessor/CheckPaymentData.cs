using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor
{
    public class CheckPaymentData : PaymentDataBase
    {

        public String BankRoutingNumber { get; set; }

        public String BankAccountNumber { get; set; }

        public String CheckNumber { get; set; }


    }
}
