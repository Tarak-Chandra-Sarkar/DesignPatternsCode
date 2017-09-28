using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor
{
    public class EftAuthorization
    {

        public bool Authorized { get; set; }

        public int? AuthorizationCode { get; set; }

    }
}
