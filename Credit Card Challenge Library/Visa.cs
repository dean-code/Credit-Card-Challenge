namespace Clearant.Challege
{
    public class Visa : CreditCard
    {
        private const double interestRate = 0.10;  // NOTE FOR CLEARENT: INTEREST RATE IS EXCLUSIVE TO THIS "BRAND" AND BUSINESS REQUIREMENTS DO NOT CALL FOR A DIFFERENT OR MULTIPLE RATES.

        public Visa()
        {
            base.InterestRate = interestRate;
        }
    }
}
