﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor
{
    public interface IEftProcessor
    {

        EftAuthorization AuthorizeEftPayment(String bankRoutingNumber, String bankAccountNumber, 
            BankAccountType bankAccountType, decimal amount);

    }
}
