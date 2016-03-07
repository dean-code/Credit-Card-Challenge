using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearant.Challege
{
    public class Wallet: IInterestCalculable
    {
        private List<CreditCard> creditCards = new List<CreditCard>();
        public List<CreditCard> CreditCards
        {
            get { return creditCards; }
            private set { creditCards = value; }
        }

        public double CalculateSimpleInterest()
        {
            double totalInterest = 0;
            foreach (var creditCard in CreditCards)
            {
                totalInterest += creditCard.CalculateSimpleInterest();
            }
            return totalInterest;
        }
    }
}
