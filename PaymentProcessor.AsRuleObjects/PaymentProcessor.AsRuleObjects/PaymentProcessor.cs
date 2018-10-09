using PaymentProcessor.AsRuleObjects.PaymentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.AsRuleObjects
{
    public class PaymentProcessor
    {

        public PaymentProcessor()
        {
            this.paymentHandlers = new List<IPaymentTypeHandler>();
        }


        private List<IPaymentTypeHandler> paymentHandlers;



        public void AddPaymentHandler(IPaymentTypeHandler handler)
        {
            this.paymentHandlers.Add(handler);
        }



        public PaymentResult ProcessPayment(PaymentDataBase paymentData)
        {
            var handler = this.paymentHandlers.FirstOrDefault(h => h.CanProcessPayment(paymentData));

            if (handler != null)
            {
                return handler.ProcessPayment(paymentData);
            }
            else
            {
                throw new ApplicationException("Unable to Process Payment Type");
            }

        }

    }
}
