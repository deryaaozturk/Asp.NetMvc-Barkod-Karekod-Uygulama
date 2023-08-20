using KarekodBarkodUygulaması.Models;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace KarekodBarkodUygulaması.Controllers
{
    // TODO siparişlerin kargoya verilmesi. 
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IProductsRepository productsRepository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, IProductsRepository productService, Cart cartService)
        {
            orderRepository = repoService;
            productsRepository = productService;
            cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Üzgünüz, sepetinizde ürün bulunmamakta!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Order/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}
