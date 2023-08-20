using KarekodBarkodUygulaması.Models;
using KarekodBarkodUygulaması.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Controllers
{
    // TODO admin sayfasına siparişlerin düzenlenmesi.
    public class AccountController : Controller
    {
        private UserManager<UserModel> userManager;
        private SignInManager<UserModel> signInManager;
        public AccountController(UserManager<UserModel> userMgr,
                SignInManager<UserModel> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        public ViewResult Register(string returnUrl)
        {
            return View(new RegisterModel
            {
                ReturnUrl = returnUrl
            });
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registermodel)
        {
            if (ModelState.IsValid)
            {
                if (registermodel.Password == registermodel.PasswordConfirm)
                {
                    UserModel user = new UserModel(registermodel.UserName);
                    user.Name = registermodel.Name;
                    user.Email = registermodel.Mail;
                    user.LastName = registermodel.LastName;
                    user.PhoneNumber = registermodel.TelefonNumarasi;
                    user.UserAdres = registermodel.Adres;
                    //await userManager.CreateAsync(user, registermodel.Password);
                    var result = await userManager.CreateAsync(user, registermodel.Password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("/userProfil");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Şifreler uyuşmamaktadır");
                }
            }
            else
            {
                ModelState.AddModelError("", "Hatalı Giriş Yaptınız");
            }
            return View(registermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/userProfil");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
