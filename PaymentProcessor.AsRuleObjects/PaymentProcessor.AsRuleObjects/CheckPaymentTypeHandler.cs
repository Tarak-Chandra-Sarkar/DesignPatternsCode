using PaymentProcessor.AsRuleObjects.PaymentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.AsRuleObjects
{
    public class CheckPaymentTypeHandler : IPaymentTypeHandler
    {

        public CheckPaymentTypeHandler(IPaymentsDao paymentsDao)
        {
            this.paymentsDao = paymentsDao;
        }


        private IPaymentsDao paymentsDao;


        public bool CanProcessPayment(PaymentDataBase paymentData)
        {
            return paymentData.PaymentType == PaymentType.CHECK;
        }


        public PaymentResult ProcessPayment(PaymentDataBase paymentData)
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
    }
}
