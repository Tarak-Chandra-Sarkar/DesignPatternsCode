using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public class CheckPaymentTypeHandler : PaymentTypeHandlerBase
    {

        public CheckPaymentTypeHandler(IPaymentTypeHandler nextPaymentHandler, IPaymentsDao paymentsDao) 
            : base(nextPaymentHandler)
        {            
            this.paymentsDao = paymentsDao;
        }


        private IPaymentsDao paymentsDao;


        public override PaymentResult TryProcessPayment(PaymentDataBase paymentData)
        {
            if (paymentData.PaymentType == PaymentType.CHECK)
            {
                CheckPaymentData checkPaymentData = paymentData as CheckPaymentData;

                int referenceNumber = this.paymentsDao.SaveCheckPayment(checkPaymentData);
                PaymentResult paymentResult = new PaymentResult()
                {
                    CustomerAccountNumber = checkPaymentData.CustomerAccountNumber,
                    PaymentDate = checkPaymentData.PaymentDate,
                    Success = true,
                    ReferenceNumber = referenceNumber
                };
                return paymentResult;
            }
            else if (this.NextPaymentTypeHandler != null)
            {
                return this.NextPaymentTypeHandler.TryProcessPayment(paymentData);
            }
            else
            {
                throw new ApplicationException("Unknown payment type");
            }
        }


    }
}
