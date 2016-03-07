using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearant.Challege
{
    public class CreditCard : IInterestCalculable
    {
        private double balance = 100;
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        private double interestRate = 0;
        public virtual double InterestRate
        {
            get
            {
                return interestRate;
            }
            protected set
            {
                interestRate = value;
            }
        }

        public double CalculateSimpleInterest()
        {
            return InterestRate * Balance;  //
        }
    }
}
