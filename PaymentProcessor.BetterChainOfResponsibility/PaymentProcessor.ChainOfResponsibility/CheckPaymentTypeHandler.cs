using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.BetterChainOfResponsibility
{
    public class CheckPaymentTypeHandler : PaymentTypeHandlerBase
    {

        public CheckPaymentTypeHandler(IPaymentTypeHandler nextPaymentHandler, IPaymentsDao paymentsDao) 
            : base(nextPaymentHandler)
        {            
            this.paymentsDao = paymentsDao;
        }


        private IPaymentsDao paymentsDao;


        protected override bool CanProcessPayment(PaymentDataBase paymentData)
        {
            return paymentData.PaymentType == PaymentType.CHECK;
        }

        protected override PaymentResult ExecutePaymentProcess(PaymentDataBase paymentData)
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
