using ForTravellers.Data;
using ForTravellers.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForTravellers.Controllers
{
 
        public class AccountController : Controller
        {
            private readonly DbContextTour _context;
            //Dependency injection
            public AccountController(DbContextTour context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View(_context.UserAccounts.ToList());
            }
            public IActionResult Registration()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Registration(RegistrationVm model)
            {
                if (ModelState.IsValid)
                {
                    UserAccount account = new UserAccount();
                    account.Email = model.Email;
                    account.FirstName = model.FirstName;
                    account.LastName = model.LastName;
                    account.UserName = model.UserName;
                    account.Password = model.Password;

                    try
                    {
                        _context.UserAccounts.Add(account);
                        _context.SaveChanges();

                        ModelState.Clear();
                        ViewBag.Message = $" {account.FirstName} {account.LastName}, Registration Successful. Please back to login!";

                    }
                    catch (DbUpdateException ex)
                    {

                        ModelState.AddModelError("", "Please enter a unique email or password.");
                        return View(model);
                    }
                    return View();
                }
                return View(model);
            }
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login(LoginVm model)
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.UserName == model.UserNameOrEmail || u.Email == model.UserNameOrEmail && u.Password == model.Password);

                    if (user != null)
                    {
                        //Success create Cookie

                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name", user.FirstName),
                        new Claim(ClaimTypes.Role, "User")

                    };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToAction("SecurePage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username/Email or password");
                        return View();
                    }
                }
                return View(model);
            }

            public IActionResult Logout()
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index");
            }

            [Authorize]
            public IActionResult SecurePage()
            {
                ViewBag.Name = HttpContext.User.Identity.Name;
                return View();
            }
            public IActionResult AddPkg()
            {
                return View();
            }

        [HttpPost]
        public IActionResult AddPkg(Pkg p, string Offers, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                string rootPath = Directory.GetCurrentDirectory();
                string uploadsFolder = Path.Combine(rootPath, "wwwroot", "~/Images");
                string filePath = Path.Combine(uploadsFolder, Path.GetFileName(image.FileName));
                image.CopyTo(new FileStream(filePath, FileMode.Create));
                var pkg = _context.Packages.Where(x => x.Offer == Offers);
                p.Image = image.FileName;
                p.Offer = Offers;
                _context.Packages.Add(p);
                _context.SaveChanges();
                ViewBag.pk = "package added successfully";
                return View();
            }
            return View();
        }
        public IActionResult Services()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Services(Service ser, string Service, IFormFile image)
            {

                string rootPath = Directory.GetCurrentDirectory();
                string uploadsFolder = Path.Combine(rootPath, "wwwroot", "Images");
                string filePath = Path.Combine(uploadsFolder, Path.GetFileName(image.FileName));
                image.CopyTo(new FileStream(filePath, FileMode.Create));

                ser.Image = image.FileName;
                ser.Services = Service;
                _context.Services.Add(ser);
                _context.SaveChanges();
                ViewBag.se = "service added successfully";
                return View();
            }
        }
}
