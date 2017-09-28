using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public class PaymentProcessor : IPaymentProcessor
    {

        public PaymentProcessor(IPaymentTypeHandler initialPaymentTypeHandler)
        {
            this.initialPaymentTypeHandler = initialPaymentTypeHandler;
        }


        private IPaymentTypeHandler initialPaymentTypeHandler;



        public PaymentResult ProcessPayment(PaymentDataBase paymentData)
        {
            return this.initialPaymentTypeHandler.TryProcessPayment(paymentData);
        }
    }
}
