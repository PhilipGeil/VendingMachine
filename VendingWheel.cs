using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VendingWheel
    {
		public Stack<Product> products = new Stack<Product>(); //Used stack for real life experience, where it is filled from the front, and therefore the newest product will also be the first to buy


		private Product product;

		public Product Product
		{
			get { return product; }
			set { product = value; }
		}


		public VendingWheel(Product product) 
		{
			this.Product = product;
			for (int i = 0; i < 5; i++)
			{
				this.products.Push(product);
			}
		}
		/// <summary>
		/// A method that simulates the wheel spinning, and then therefore "droping" the product to the user
		/// </summary>
		/// <returns>returns the product choosen</returns>
		public Product Spin() 
		{
			return products.Pop();
		}

	}
}
