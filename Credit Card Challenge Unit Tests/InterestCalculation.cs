using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clearant.Challege;

namespace Clearant.Challege.Tests
{
    [TestClass]
    public class InterestCalculation
    {
        private const double expectedVisaInterestRate = 0.10;
        private const double expectedMCInterestRate = 0.05;
        private const double expectedDiscoverInterestRate = 0.01;
        private const double expectedCardBalance = 100;

        [TestMethod]
        public void ForMC()
        {
            var mc = new MC();
            ValidateCreditCard(mc);
            ValidateTotalInterest(mc);
        }

        [TestMethod]
        public void ForVisa()
        {
            var visa = new Visa();
            ValidateCreditCard(visa);
            ValidateTotalInterest(visa);
        }

        [TestMethod]
        public void ForDiscover()
        {
            var discover = new Discover();
            ValidateCreditCard(discover);
            ValidateTotalInterest(discover);
        }

        [TestMethod]
        public void ForWallet()
        {
            ValidateTotalInterest(new Wallet());
        }

        [TestMethod]
        public void ForPerson()
        {
            ValidateTotalInterest(new Person());
        }

        /// <summary>
        /// Challenge Test Case 1
        /// 
        /// Tests:
        /// - Validate Total Interest Per Person
        /// - Validate Total Interest Per Card
        /// 
        /// Criteria:
        /// - 1 Person
        /// - 1 Wallet
        /// - Wallet has 3 cards (1 MC, 1 Visa, 1 Discover)
        /// </summary>
        [TestMethod]
        public void TestCase1()
        {
            var mc = new MC();
            var visa = new Visa();
            var discover = new Discover();
            var wallet = new Wallet();
            var person = new Person();

            wallet.CreditCards.Add(mc);
            wallet.CreditCards.Add(visa);
            wallet.CreditCards.Add(discover);
            person.Wallets.Add(wallet);

            ValidateTotalInterest(mc);
            ValidateTotalInterest(visa);
            ValidateTotalInterest(discover);
            ValidateTotalInterest(person);
        }

        /// <summary>
        /// Challenge Test Case 2
        /// 
        /// Tests:
        /// - Validate Total Interest Per Person
        /// - Validate Total Interest Per Wallet
        /// 
        /// Criteria:
        /// - 1 Person
        /// - 2 Wallets
        /// - Wallet 1 has 2 cards (1 Visa, 1 Discover)
        /// - Wallet 2 has 1 cards (1 MC)
        /// </summary>
        [TestMethod]
        public void TestCase2()
        {
            // SETUP CASE
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var person = new Person();

            wallet1.CreditCards.Add(new Visa());
            wallet1.CreditCards.Add(new Discover());
            wallet2.CreditCards.Add(new MC());
            person.Wallets.Add(wallet1);
            person.Wallets.Add(wallet2);

            // VALIDATE CASE
            ValidateTotalInterest(wallet1);
            ValidateTotalInterest(wallet2);
            ValidateTotalInterest(person);
        }

        /// <summary>
        /// Challenge Test Case 3
        /// 
        /// Tests:
        /// - Validate Total Interest Per Person
        /// - Validate Total Interest Per Wallet
        /// 
        /// Criteria:
        /// - 2 Persons
        /// - 1 Wallet Per Person
        /// - Person 1 Wallet has 3 cards (1 MC, 1 Visa, 1 Discover)
        /// - Person 2 Wallet has 2 cards (1 MC, 1 Visa)
        /// </summary>
        [TestMethod]
        public void TestCase3()
        {
            // SETUP CASE
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var person1 = new Person();
            var person2 = new Person();

            wallet1.CreditCards.Add(new MC());
            wallet1.CreditCards.Add(new Visa());
            wallet1.CreditCards.Add(new Discover());
            wallet2.CreditCards.Add(new MC());
            wallet2.CreditCards.Add(new Visa());
            person1.Wallets.Add(wallet1);
            person2.Wallets.Add(wallet2);

            // VALIDATE CASE
            ValidateTotalInterest(wallet1);
            ValidateTotalInterest(wallet2);
            ValidateTotalInterest(person1);
            ValidateTotalInterest(person2);
        }


        private double GetExpectedTotalInterest(CreditCard creditCard)
        {
            double totalInterest = 0;

            if (creditCard is Visa)
            {
                totalInterest = expectedCardBalance * expectedVisaInterestRate;
            }
            else if (creditCard is MC)
            {
                totalInterest = expectedCardBalance * expectedMCInterestRate;
            }
            else if (creditCard is Discover)
            {
                totalInterest = expectedCardBalance * expectedDiscoverInterestRate;
            }

            return totalInterest;
        }

        private double GetExpectedTotalInterest(Wallet wallet)
        {
            double totalInterest = 0;

            foreach (CreditCard creditCard in wallet.CreditCards)
            {
                totalInterest += GetExpectedTotalInterest(creditCard);
            }

            return totalInterest;
        }

        private double GetExpectedTotalInterest(Person person)
        {
            double totalInterest = 0;

            foreach (Wallet wallet in person.Wallets)
            {
                foreach (CreditCard creditCard in wallet.CreditCards)
                {
                    totalInterest += GetExpectedTotalInterest(creditCard);
                }
            }

            return totalInterest;
        }

        private void ValidateCreditCard(CreditCard creditCard)
        {
            Assert.AreEqual(creditCard.Balance, expectedCardBalance);

            if (creditCard is Visa)
            {
                Assert.AreEqual(creditCard.InterestRate, expectedVisaInterestRate);
            }
            else if (creditCard is MC)
            {
                Assert.AreEqual(creditCard.InterestRate, expectedMCInterestRate);
            }
            else if (creditCard is Discover)
            {
                Assert.AreEqual(creditCard.InterestRate, expectedDiscoverInterestRate);
            }
            else
            {
                Assert.Fail();
            }
        }

        private void ValidateTotalInterest(CreditCard creditCard)
        {
            double result = creditCard.CalculateSimpleInterest();
            Assert.AreEqual(result, GetExpectedTotalInterest(creditCard));
        }

        private void ValidateTotalInterest(Wallet wallet)
        {
            var result = wallet.CalculateSimpleInterest();
            Assert.AreEqual(result, GetExpectedTotalInterest(wallet));
        }

        private void ValidateTotalInterest(Person person)
        {
            var result = person.CalculateSimpleInterest();
            Assert.AreEqual(result, GetExpectedTotalInterest(person));
        }
    }
}
