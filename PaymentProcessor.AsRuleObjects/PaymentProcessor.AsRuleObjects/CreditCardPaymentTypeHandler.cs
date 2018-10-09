using PaymentProcessor.AsRuleObjects.PaymentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.AsRuleObjects
{
    public class CreditCardPaymentTypeHandler : IPaymentTypeHandler
    {

        public CreditCardPaymentTypeHandler(ICreditCardProcessor creditCardProcessor,
            IPaymentsDao paymentsDao)
        {
            this.creditCardProcessor = creditCardProcessor;
            this.paymentsDao = paymentsDao;
        }


        private ICreditCardProcessor creditCardProcessor;
        private IPaymentsDao paymentsDao;



        public bool CanProcessPayment(PaymentDataBase paymentData)
        {
            return paymentData.PaymentType == PaymentType.CREDIT_CARD;
        }


        public PaymentResult ProcessPayment(PaymentDataBase paymentData)
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
    }
}
