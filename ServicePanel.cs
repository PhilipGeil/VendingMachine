using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class ServicePanel
    {
        public Wallet wallet = new Wallet();

        public ServicePanel() { }
        /// <summary>
        /// Gets the coins input from which the user has entered.
        /// </summary>
        /// <returns>returns an integer which is the value of the coins that has been put into the machine</returns>
        public int TakeInput()
        {
            int buffer = 0;
            Program.ShowWalletHoldings();
            bool doneYet = false;
            while (!doneYet)
            {
                do
                {
                    int input = Program.GetIndexInput("coin");
                    buffer += wallet.ShowHoldings()[input - 1][0].Values;
                    wallet.SelectPayment(wallet.ShowHoldings()[input - 1][0]); 
                } while (!Program.CheckIfDone());
                doneYet = true;
            }
            return buffer;
        }
        /// <summary>
        /// Handles the input, given from the number the user has choosen, and then orders it, into an array, with two values, for the vending machine to handle from there
        /// </summary>
        /// <returns>returns an array with two values, which will be used by the vending machine, to identify which vendingwheel to start</returns>
        public int[] TakeOrder()
        {

            int order = Program.GetIndexInput("product");
            int[] doneOrder = new int[2];
            switch (order)
            {
                case 1:
                    doneOrder[0] = 0;
                    doneOrder[1] = 0;
                    break;
                case 2:
                    doneOrder[0] = 0;
                    doneOrder[1] = 1;
                    break;
                case 3:
                    doneOrder[0] = 0;
                    doneOrder[1] = 2;
                    break;
                case 4:
                    doneOrder[0] = 1;
                    doneOrder[1] = 0;
                    break;
                case 5:
                    doneOrder[0] = 1;
                    doneOrder[1] = 1;
                    break;
                case 6:
                    doneOrder[0] = 1;
                    doneOrder[1] = 2;
                    break;
                case 7:
                    doneOrder[0] = 2;
                    doneOrder[1] = 0;
                    break;
                case 8:
                    doneOrder[0] = 2;
                    doneOrder[1] = 1;
                    break;
                case 9:
                    doneOrder[0] = 2;
                    doneOrder[1] = 2;
                    break;
                default:
                    break;
            }
            return doneOrder;
        }
        /// <summary>
        /// Handles the payment of the money objects
        /// </summary>
        /// <returns></returns>
        public List<Money> InsertPayment()
        {

            return wallet.Pay();
        }

    }
}
