using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.BetterChainOfResponsibility
{
    public interface IPaymentProcessor
    {


        PaymentResult ProcessPayment(PaymentDataBase paymentData);


    }
}
