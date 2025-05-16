using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(ICarService _carService,UserManager<AppUser> _userManager,IBookingService _bookingService) : Controller
    {
        public async  Task<IActionResult> Index()
        {
            // 1. Toplam Araç Sayısı
            ViewBag.CarCount = _carService.TGetAll().Count();

            // 2. Toplam Kullanıcı Sayısı (sadece "User" rolü olanlar)
            var allUsers = _userManager.Users.ToList();
            var userCount = 0;
            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "User"))
                    userCount++;
            }
            ViewBag.UserCount = userCount;

            // 3. Toplam Manager Sayısı
            var managerCount = 0;
            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Manager"))
                    managerCount++;
            }
            ViewBag.ManagerCount = managerCount;

           


            // 6. En Çok Talep Edilen Araç Modeli
            var bookings = _bookingService.TGetAll();
            var popularCarId = bookings
                .GroupBy(x => x.CarId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            var popularCar = _carService.TGetById(popularCarId);
            ViewBag.PopularCarModel = popularCar != null ? popularCar.ModelName : "Veri Yok";

            // 8. Toplam Rezervasyon Sayısı
            ViewBag.BookingCount = bookings.Count();

            return View();
        }
    }
}
