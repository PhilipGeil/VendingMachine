using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VendingMachine
    {
        public OutputDrawer drawer = new OutputDrawer();
        public ServicePanel servicePanel = new ServicePanel();
        MoneyBox moneyBox = new MoneyBox();
        VendingDoor vendingDoor = new VendingDoor();
        public VendingWheel[,] wheels = new VendingWheel[3, 3];
        Refill refill = new Refill();
        public int moneyInput = 0; // Buffer variabel used for keeping track of how many moneys, the user has put into the machine


        public VendingMachine()
        {
            for (int i = 0; i < 3; i++)
            {
                wheels[i, 0] = new VendingWheel(new Chips());
                wheels[i, 1] = new VendingWheel(new Soda());
                wheels[i, 2] = new VendingWheel(new Candy());
            }
        }
        /// <summary>
        /// "Drops" the product from the vending wheel into the output drawer
        /// </summary>
        /// <param name="product">the product to "drop"</param>
        public void DropProduct(Product product)
        {
            drawer.Products.Add(product);
        }
        /// <summary>
        /// Executes the order that has been put, and also checks if the user has put enought money in it
        /// </summary>
        /// <returns></returns>
        public void ExecuteOrder()
        {
            bool check = false;
            moneyInput = servicePanel.TakeInput();
            while (!check)
            {
                Program.ShowMoneyHold();
                int[] order = servicePanel.TakeOrder();
                int orderx = order[1];
                int ordery = order[0];
                if (moneyInput >= wheels[orderx, ordery].Product.Price)
                {
                    DropProduct(wheels[orderx, ordery].Spin());
                    check = true;
                    CashIn();
                    moneyInput -= wheels[orderx, ordery].Product.Price;
                    Program.ShowChangeAmount();
                    if (wheels[orderx, ordery].products.Count == 0)
                    {
                        refill.FillProducts(wheels[orderx, ordery]);
                    }
                }
                else
                {
                    Console.WriteLine("Not enough, input more money");
                    moneyInput += servicePanel.TakeInput();
                }
            }
        }
        /// <summary>
        /// Pay out the change of the purchase
        /// </summary>
        /// <returns></returns>
        public List<string> PayOutChange()
        {
            int buffer = moneyInput;
            List<string> messages = new List<string>();
            while (buffer >= 20)
            {
                servicePanel.wallet.Moneys.Add(new Money(20));
                buffer -= 20;
                messages.Add("Gave back 20");
            }
            while (buffer >= 10)
            {
                servicePanel.wallet.Moneys.Add(new Money(10));
                buffer -= 10;
                messages.Add("Gave back 10");
            }
            while (buffer >= 5)
            {
                servicePanel.wallet.Moneys.Add(new Money(5));
                buffer -= 5;
                messages.Add("Gave back 5");
            }
            return messages;
        }


        /// <summary>
        /// Cashes in the money that has been payed for the product, and stores it in the box holding of the machine
        /// </summary>
        void CashIn()
        {
            // Service panel will not be functional if the door is open
            if (!vendingDoor.DoorState)
            {
                foreach (Money money in servicePanel.InsertPayment())
                {
                    moneyBox.Holdings.Add(money);
                }
            }
        }

    }

    class MoneyBox
    {
        private List<Money> holdings;

        public List<Money> Holdings
        {
            get { return holdings; }
            set { holdings = value; }
        }

        public MoneyBox() { }
    }

    class VendingDoor
    {
        // The state that checks whether the door is open or cloed
        // true = door open, false = door closed
        private bool doorState;

        public bool DoorState
        {
            get { return doorState; }
            set { doorState = value; }
        }

        public VendingDoor() { }
        /// <summary>
        /// Changes the state of the door, from closed to open, or the other way
        /// </summary>
        public void ChangeDoorState()
        {
            DoorState = !DoorState;
        }
    }
}
