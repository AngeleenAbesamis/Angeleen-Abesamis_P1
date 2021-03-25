using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BeautyStore.BeautyStoreModels;
using BeautyStoreDL;
using BeautyStoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BeautyStoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private Customer _customer;
        private readonly BeautyStoreDBContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger _logger;
     //  private BSRepoDB _BSRepoDB;


        public AccountController(SignInManager<IdentityUser> signinManager,
            BeautyStoreDBContext context, ILogger<IdentityUser> logger,
            UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> roleManager)
        {
            _signinManager = signinManager;
            _logger = logger;
            userManager = _userManager;
            this.roleManager = roleManager;
            _context = context;
           // _BSRepoDB = bsRepoDb;
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        public async Task CreateRole()
        {

            IdentityRole identityRole = new IdentityRole
            {
                Name = "Admin"
            };

            var exists = roleManager.RoleExistsAsync("Admin");
            if (!exists.Result)
            {
                IdentityResult result2 = await roleManager.CreateAsync(identityRole);
            }

            var user = await userManager.FindByNameAsync("admin@gmail.com");
            if (user == null)
            {
                var user2 = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",

                };
                var result = await userManager.CreateAsync(user2, "@Admin1");

                if (result.Succeeded)
                {
                    var currentUser = userManager.FindByEmailAsync(user2.Email);
                    var RoleResult = await userManager.AddToRoleAsync(currentUser.Result, "Admin");

                    if (RoleResult.Succeeded)
                    {
                        Console.WriteLine("Done..");
                    }

                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var NewInfo = await userManager.FindByEmailAsync(model.Email);

                    Customer c = new Customer();
                    c.CustomerName = model.Name;
                    c.EmailAddress = model.Email;
                    c.HomeAddress = model.HomeAddress;
                    c.BillingAddress = model.BillingAddress;
                    c.IdentityID = NewInfo.Id;
                    c.PhoneNumber = model.PhoneNumber;
                    c.Password = model.Password;


                    _context.Customers.Add(c);
                    _context.SaveChanges();
                   // await _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("logoff");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Error", error.Description);
                    Console.WriteLine(error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            try
            {
                await CreateRole();
            }
            catch (Exception e)
            {
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signinManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);


                if (result.Succeeded)
                {
                    string username = User.Identity.Name;
                    var user = await userManager.FindByNameAsync(model.Email);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToAction("Index", "home");
                    }
                    else
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToAction("Index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> logoff()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
