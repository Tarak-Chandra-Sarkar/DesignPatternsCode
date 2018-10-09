using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.AsRuleObjects.PaymentObjects
{
    public class EftPaymentData : PaymentDataBase
    {
        public EftPaymentData()
        {
            this.PaymentType = PaymentType.EFT;
        }

        public BankAccountType AccountType { get; set; }

        public String RoutingNumber { get; set; }

        public String BankAccountNumber { get; set; }
    }
}
