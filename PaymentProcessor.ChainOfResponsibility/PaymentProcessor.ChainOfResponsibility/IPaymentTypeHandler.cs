﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.ChainOfResponsibility
{
    public interface IPaymentTypeHandler
    {

        /// <summary>
        /// Gets the next payment handler that follows this one.  If this proeprty returns
        /// null, then we are at the end of the chain
        /// </summary>
        IPaymentTypeHandler NextPaymentTypeHandler { get; }

        /// <summary>
        /// Try to process the payment.  If we can, then we'll return.  Otherwise
        /// we'll call the next payment handler in the chain
        /// </summary>
        /// <param name="paymentData"></param>
        /// <returns></returns>
        PaymentResult TryProcessPayment(PaymentDataBase paymentData);

    }
}
