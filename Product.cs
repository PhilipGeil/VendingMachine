using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Product
    {
		private string name;

		public string Name
		{
			get { return name; }
			private set { name = value; }
		}

		private string brand;

		public string Brand
		{
			get { return brand; }
			private set { brand = value; }
		}

		private int price;

		public int Price
		{
			get { return price; }
			private set { price = value; }
		}


		public Product(string name, string brand, int price) 
		{
			Name = name;
			Brand = brand;
			Price = price;
		}


	}

	class Chips : Product
	{
		private int weight;

		public int Weight
		{
			get { return weight; }
			private set { weight = value; }
		}

		public Chips() : base("Chips", "Kim's", 20)
		{
			Weight = 50;
		}

	}

	class Soda : Product
	{
		private double liters;

		public double Liters
		{
			get { return liters; }
			private set { liters = value; }
		}

		public Soda() : base("Soda", "Pepsi", 25)
		{
			liters = 0.5;
		}

	}

	class Candy : Product
	{
		private int weight;

		public int Weight
		{
			get { return weight; }
			private set { weight = value; }
		}

		public Candy() : base("Candy", "Haribo", 20)
		{
			Weight = 60;
		}

	}
}
