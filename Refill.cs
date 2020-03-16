using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Refill
    {

        public Refill() { }
        /// <summary>
        /// Refills the products in the vending wheels
        /// </summary>
        /// <param name="wheelToFill"></param>
        public void FillProducts(VendingWheel wheelToFill)
        {
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product(wheelToFill.Product.Name, wheelToFill.Product.Brand, wheelToFill.Product.Price);
                product = wheelToFill.Product;
                wheelToFill.products.Push(product);
            }

        }

    }
}
