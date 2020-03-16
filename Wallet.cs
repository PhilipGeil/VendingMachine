using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Wallet
    {
        private List<Money> moneys = new List<Money>();
        private List<Money> tempMoneys = new List<Money>();

        public List<Money> Moneys
        {
            get { return moneys; }
            set { moneys = value; }
        }

        public Wallet()
        {
            FillWallet();
        }
        /// <summary>
        /// Takes the money from the wallet, and places them in a temporary list, to keep track of what the user has selected
        /// </summary>
        /// <param name="money"></param>
        public void SelectPayment(Money money)
        {
            tempMoneys.Add(money);
            Moneys.Remove(money);
        }
        /// <summary>
        /// The pay function executes the payment, from the money in the temporary list, and then clears it
        /// </summary>
        /// <returns>returns a list of money, that represents the payment</returns>
        public List<Money> Pay()
        {
            List<Money> buffer;
            buffer = tempMoneys;
            tempMoneys.Clear();
            return buffer;
        }
        /// <summary>
        /// a method that fills the wallet with some money
        /// </summary>
        void FillWallet()
        {
            for (int i = 0; i < 5; i++)
            {
                moneys.Add(new Money(20));
                moneys.Add(new Money(10));
                moneys.Add(new Money(5));
            }
        }
        /// <summary>
        /// A method that sorts the money, and then stores it sorted in a list
        /// </summary>
        /// <returns>returns a list of money, where it has been sorted, and made easy for print out</returns>
        public List<List<Money>> ShowHoldings()
        {
            List<List<Money>> holdings = new List<List<Money>>();
            List<Money> twenties = new List<Money>();
            List<Money> tens = new List<Money>();
            List<Money> fives = new List<Money>();
            foreach (Money money in Moneys)
            {
                if (money.Values == 20)
                {
                    twenties.Add(money);
                }
                else if (money.Values == 10)
                {
                    tens.Add(money);
                }
                else
                {
                    fives.Add(money);
                }
            }
            holdings.Add(twenties);
            holdings.Add(tens);
            holdings.Add(fives);
            return holdings;
        }

    }
}
