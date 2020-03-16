using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class OutputDrawer
    {
		private List<Product> products = new List<Product>();

		public List<Product> Products
		{
			get { return products; }
			set { products = value; }
		}

		public OutputDrawer() {}

	}
}
