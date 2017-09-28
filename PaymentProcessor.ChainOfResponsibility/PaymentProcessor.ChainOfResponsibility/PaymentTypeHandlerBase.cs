using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public abstract class PaymentTypeHandlerBase : IPaymentTypeHandler
    {

        /// <summary>
        /// Creates a new PaymentTypeHandler object, taking in the successor to this handler
        /// that would be called next if this handler cannot handle this payment type
        /// </summary>
        /// <param name="nextPaymentHandler"></param>
        public PaymentTypeHandlerBase (IPaymentTypeHandler nextPaymentHandler)
        {
            this.paymentTypeHandler = nextPaymentHandler;
        }


        private IPaymentTypeHandler paymentTypeHandler;


        /// <summary>
        /// Gets the next payment handler that follows this one.  If this proeprty returns
        /// null, then we are at the end of the chain
        /// </summary>
        public IPaymentTypeHandler NextPaymentTypeHandler
        {
            get
            {
                return this.paymentTypeHandler;
            }
        }


        /// <summary>
        /// Try to process the payment.  If we can, then we'll return.  Otherwise
        /// we'll call the next payment handler in the chain
        /// </summary>
        /// <param name="paymentData"></param>
        /// <returns></returns>
        public abstract PaymentResult TryProcessPayment(PaymentDataBase paymentData);


    }
}
