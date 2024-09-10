using ForTravellers.Data;
using ForTravellers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForTravellers.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextTour _context;
        //Dependency injection
        public UserController(DbContextTour context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Services()
        {
            var tours = _context.Services.ToList();
            return View(tours);
        }

        public IActionResult Packages()
        {
            var package = _context.Packages.ToList();
            return View(package);
        }

        public IActionResult Reservation( Reservation res)
        {

            _context.Reservations.Add(res);
            _context.SaveChanges();
            TempData["ReservationId"] = res.RegistrationId; // Simpan ID reservasi di TempData
            return RedirectToAction("Payment");

           
        }
        public IActionResult Paynment() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(string p)
        {
            if (TempData["ReservationId"] is int reservationId)
            {
                Payment pay = new Payment
                {
                    PaymentMethod = p,
                    RegId = reservationId
                };
                _context.Payments.Add(pay);
                _context.SaveChanges();
                TempData.Remove("ReservationId"); // Hapus data dari TempData setelah digunakan
                return RedirectToAction("Packages");
              
            }
            return View();
            //  else
            //  {
            //      // Tangani kasus di mana ReservationId tidak tersedia di TempData
            //      return RedirectToAction("Index", "Home");
            //  }


            //  int id = (int)Session{ "Reservation" };
            //  Payment paymentM = new Payment();
            //paymentM.PaymentMethod = p; 
            //paymentM.RegId = id;
            //_context.Payments.Add(paymentM);
            //_context.SaveChanges();
            //  Session.Remove("Reservation");
            //  return RedirectToAction("Packages");
            //  return View();
        }
    }
}
