using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private DatabaseContext context;
        private IProductsRepository repository;

        public EFOrderRepository(DatabaseContext ctx, IProductsRepository productsRepository)
        {
            context = ctx;
            repository = productsRepository;
        }

        public IQueryable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
            foreach (CartLine lines in order.Lines)
            {
                Product urun = repository.Products.FirstOrDefault(p => p.productID == lines.Product.productID);
                urun.productAdet -= lines.Quantity;
                repository.SaveProducts(urun);
            }
        }
    }
}
