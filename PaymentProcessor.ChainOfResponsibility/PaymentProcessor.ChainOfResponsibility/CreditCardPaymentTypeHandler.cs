using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public class CreditCardPaymentTypeHandler : PaymentTypeHandlerBase
    {

        public CreditCardPaymentTypeHandler(IPaymentTypeHandler nextPaymentHandler, ICreditCardProcessor creditCardProcessor,
            IPaymentsDao paymentsDao) 
            : base(nextPaymentHandler)
        {
            this.creditCardProcessor = creditCardProcessor;
            this.paymentsDao = paymentsDao;
        }


        private ICreditCardProcessor creditCardProcessor;
        private IPaymentsDao paymentsDao;


        public override PaymentResult TryProcessPayment(PaymentDataBase paymentData)
        {
            if ( paymentData.PaymentType == PaymentType.CREDIT_CARD)
            {
                CreditCardPaymentData creditCardData = paymentData as CreditCardPaymentData;

                CreditCardResult authResult = this.creditCardProcessor.AuthorizeCreditCard(creditCardData.CreditCardNumber,
                    creditCardData.ExpirationDate, creditCardData.Cvv, creditCardData.BillingZipCode, creditCardData.Amount);

                if (authResult.Authorized == true)
                {
                    int referenceNumber = paymentsDao.SaveSuccessfulCreditCardPayment(creditCardData, authResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = creditCardData.CustomerAccountNumber,
                        PaymentDate = creditCardData.PaymentDate,
                        Success = authResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };
                    return paymentResult;
                }
                else
                {
                    int referenceNumber = paymentsDao.SaveFailedCreditCardPayment(creditCardData, authResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = creditCardData.CustomerAccountNumber,
                        PaymentDate = creditCardData.PaymentDate,
                        Success = authResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };
                    return paymentResult;
                }
            }
            else if ( this.NextPaymentTypeHandler != null)
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
