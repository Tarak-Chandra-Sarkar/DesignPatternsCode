using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentProcessor.ChainOfResponsibility.Tests
{
    public class PaymentProcessorTests
    {

        public PaymentProcessor CreatePaymentProcessor()
        {
            IPaymentsDao paymentsDao = new PaymentsDao();
            ICreditCardProcessor creditCardProcessor = new CreditCardProcessor();
            IEftProcessor eftProcessor = new EftProcessor();

            CheckPaymentTypeHandler checkHandler = new CheckPaymentTypeHandler(null, paymentsDao);
            EftPaymentTypeHandler eftPaymentHandler = new EftPaymentTypeHandler(checkHandler, eftProcessor, paymentsDao);
            CreditCardPaymentTypeHandler creditCardHandler = new CreditCardPaymentTypeHandler(eftPaymentHandler,
                creditCardProcessor, paymentsDao);

            PaymentProcessor paymentProcessor = new PaymentProcessor(creditCardHandler);
            return paymentProcessor;
        }


        [Fact]
        public void TestSuccessfulCreditCardPayment()
        {
            //Arrange
            PaymentProcessor paymentProcessor = this.CreatePaymentProcessor();
            CreditCardPaymentData creditCardPayment = new CreditCardPaymentData()
            {
                CreditCardNumber = SampleData.CARD_NUMBER_ONE,
                ExpirationDate = "10/2019",
                Cvv = "755",
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                BillingZipCode = "60067",
                CardholderName = "John Doe",
                Amount = 100.00m
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(creditCardPayment);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(10, result.ReferenceNumber);
        }


        [Fact]
        public void TestFailingCreditCardPayment()
        {
            //Arrange
            PaymentProcessor paymentProcessor = this.CreatePaymentProcessor();
            CreditCardPaymentData creditCardPayment = new CreditCardPaymentData()
            {
                CreditCardNumber = SampleData.CARD_NUMBER_ONE,
                ExpirationDate = "10/2019",
                Cvv = "755",
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                BillingZipCode = "60067",
                CardholderName = "John Doe",
                Amount = 10000.00m
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(creditCardPayment);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(15, result.ReferenceNumber);
        }



        [Fact]
        public void TestSuccessfulEftPayment()
        {
            //Arrange
            PaymentProcessor paymentProcessor = this.CreatePaymentProcessor();
            EftPaymentData eftPaymentData = new EftPaymentData()
            {
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                Amount = 100.00m,
                RoutingNumber = SampleData.BANK_ROUTING_ONE,
                BankAccountNumber = SampleData.BANK_ACCOUNT_ONE,
                AccountType = BankAccountType.CHECKING
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(eftPaymentData);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(20, result.ReferenceNumber);
        }


        [Fact]
        public void TestFailingEftPayment()
        {
            //Arrange
            PaymentProcessor paymentProcessor = this.CreatePaymentProcessor();
            EftPaymentData eftPaymentData = new EftPaymentData()
            {
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                Amount = 100.00m,
                RoutingNumber = SampleData.BANK_ROUTING_ONE,
                BankAccountNumber = SampleData.BANK_ACCOUNT_TWO,
                AccountType = BankAccountType.CHECKING
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(eftPaymentData);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(25, result.ReferenceNumber);
        }


        [Fact]
        public void TestCheckPayment()
        {
            //Arrange
            PaymentProcessor paymentProcessor = this.CreatePaymentProcessor();

            CheckPaymentData checkPaymentData = new CheckPaymentData()
            {
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                Amount = 100.00m,
                BankRoutingNumber = SampleData.BANK_ROUTING_ONE,
                BankAccountNumber = SampleData.BANK_ACCOUNT_TWO,
                CheckNumber = "500"
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(checkPaymentData);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(30, result.ReferenceNumber);
        }

    }
}
