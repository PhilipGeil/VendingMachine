using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Money
    {
		private int values;

		public int Values
		{
			get { return values; }
			set { values = value; }
		}

		public Money(int value) 
		{
			this.Values = value;
		}

	}
}
