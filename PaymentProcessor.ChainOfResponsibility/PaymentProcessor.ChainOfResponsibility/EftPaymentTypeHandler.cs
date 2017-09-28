using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public class EftPaymentTypeHandler : PaymentTypeHandlerBase
    {


        public EftPaymentTypeHandler(IPaymentTypeHandler nextPaymentHandler, IEftProcessor eftProcessor,
            IPaymentsDao paymentsDao) 
            : base(nextPaymentHandler)
        {
            this.eftProcessor = eftProcessor;
            this.paymentsDao = paymentsDao;
        }


        private IEftProcessor eftProcessor;
        private IPaymentsDao paymentsDao;


        public override PaymentResult TryProcessPayment(PaymentDataBase paymentData)
        {
            if ( paymentData.PaymentType == PaymentType.EFT)
            {
                EftPaymentData eftPaymentData = paymentData as EftPaymentData;

                EftAuthorization eftResult = this.eftProcessor.AuthorizeEftPayment(eftPaymentData.RoutingNumber,
                    eftPaymentData.BankAccountNumber, eftPaymentData.AccountType, eftPaymentData.Amount);

                if (eftResult.Authorized)
                {
                    int referenceNumber = paymentsDao.SaveSuccessfulEftPayment(eftPaymentData, eftResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = eftPaymentData.CustomerAccountNumber,
                        PaymentDate = eftPaymentData.PaymentDate,
                        Success = eftResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };

                    return paymentResult;
                }
                else
                {
                    int referenceNumber = paymentsDao.SaveFailedEftPayment(eftPaymentData, eftResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = eftPaymentData.CustomerAccountNumber,
                        PaymentDate = eftPaymentData.PaymentDate,
                        Success = eftResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };
                    return paymentResult;
                }
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
