using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KarekodBarkodUygulamasý.Infrastructure;
using KarekodBarkodUygulamasý.Models;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulamasý.Pages {

    public class CartModel : PageModel {
        private IProductsRepository repository;

        public CartModel(IProductsRepository repo, Cart cartService) {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long productID, string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.productID == productID);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostAdd(long productID, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.productID == productID);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl) {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Product.productID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostCikar(int productID, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.productID == productID);
            Cart.DeleteItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
