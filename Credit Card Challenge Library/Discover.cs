using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearant.Challege
{
    public class Discover : CreditCard
    {
        private const double interestRate = 0.01;

        public Discover()
        {
            base.InterestRate = interestRate;
        }
    }
}
