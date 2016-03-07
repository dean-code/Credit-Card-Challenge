using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearant.Challege
{
    public class MC : CreditCard
    {
        private const double interestRate = 0.05;  // NOTE FOR CLEARENT: INTEREST RATE IS EXCLUSIVE TO THIS "BRAND" AND BUSINESS REQUIREMENTS DO NOT CALL FOR A DIFFERENT OR MULTIPLE RATES.

        public MC()
        {
            base.InterestRate = interestRate;
        }
    }
}
