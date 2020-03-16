using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static VendingMachine vendingMachine = new VendingMachine();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vending Machine");
                Console.WriteLine("1: Buy a product");
                Console.WriteLine("2: Show the products you have bought");
                Console.WriteLine("3: Show the amount of money's you have");
                Menu(int.Parse(Console.ReadLine()));
            }
        }
        /// <summary>
        /// Method to show and handle the start menu
        /// </summary>
        /// <param name="choice"></param>
        static void Menu(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ShowItems();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    ShowBoughtProducts();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    ShowWalletHoldings();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Shows the money holds that the user has put into the machine during a purchase
        /// </summary>
        public static void ShowMoneyHold()
        {
            Console.WriteLine("You have put a total of {0} DKK in the machine", vendingMachine.moneyInput);
        }
        /// <summary>
        /// Shows all the different items, that can be bought in the machine
        /// </summary>
        public static void ShowItems()
        {
            int chooseIndex = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(chooseIndex + ": " + vendingMachine.wheels[j, i].Product.Name + " " + " - " + vendingMachine.wheels[j, i].Product.Price + ",-DKK  --  ");
                    chooseIndex++;
                }
                Console.WriteLine();
            }
            vendingMachine.ExecuteOrder();
        }
        /// <summary>
        /// Shows the amount of change from the purchase
        /// </summary>
        public static void ShowChangeAmount()
        {
            foreach (string text in vendingMachine.PayOutChange())
            {
                Console.WriteLine(text);
            }
        }
        /// <summary>
        /// Shows the products that has been purchased so far
        /// </summary>
        static void ShowBoughtProducts()
        {
            foreach (Product prod in vendingMachine.drawer.Products)
            {
                Console.WriteLine(prod.Name);
            }
        }
        /// <summary>
        /// Shows what is left in the users wallet, sorted into the 3 coins, 20, 10 and 5
        /// </summary>
        public static void ShowWalletHoldings()
        {

            Console.WriteLine("1: You have {0} x {1} DKK in your wallet", vendingMachine.servicePanel.wallet.ShowHoldings()[0].Count, 20);
            Console.WriteLine("2: You have {0} x {1} DKK in your wallet", vendingMachine.servicePanel.wallet.ShowHoldings()[1].Count, 10);
            Console.WriteLine("3: You have {0} x {1} DKK in your wallet", vendingMachine.servicePanel.wallet.ShowHoldings()[2].Count, 5);
        }
        /// <summary>
        /// Used for when the user has to choose which coin or product they wish, this method then handles the input
        /// </summary>
        /// <param name="subject"></param>
        /// <returns>return the input from the user</returns>
        public static int GetIndexInput(string subject)
        {
            Console.WriteLine("Enter your choice for which {0}: ", subject);
            int input = int.Parse(Console.ReadLine());
            return input;
        }
        /// <summary>
        /// Checks whether the user is done putting coins into the machine
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfDone()
        {
            Console.WriteLine("Are you finished?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
