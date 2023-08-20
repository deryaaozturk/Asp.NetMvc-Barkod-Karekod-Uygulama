using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    public class Cart
    {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Product.productID == product.productID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void DeleteItem(Product product,int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Product.productID == product.productID)
                .FirstOrDefault();

            if ((line.Quantity - quantity) <= 0)
            {
                RemoveLine(product);
            }
            else
            {
                line.Quantity = line.Quantity - quantity;
            }
        }

        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.productID == product.productID);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => Convert.ToDecimal(e.Product.productFiyat) * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
