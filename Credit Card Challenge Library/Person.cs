using System.Collections.Generic;

namespace Clearant.Challege
{
    public class Person: IInterestCalculable
    {
        private List<Wallet> wallets = new List<Wallet>();
        public List<Wallet> Wallets
        {
            get { return wallets; }
            private set { wallets = value; }
        }

        public double CalculateSimpleInterest()
        {
            double totalInterest = 0;
            foreach (var wallet in Wallets)
            {
                totalInterest += wallet.CalculateSimpleInterest();
            }
            return totalInterest;
        }
    }
}
