﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.AsRuleObjects
{
    public class CreditCardResult
    {

        public bool Authorized { get; set; }

        public String AuthorizationCode { get; set; }        

    }
}
