using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminDashboardController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBookingService _bookingService;
        private readonly IReviewService _reviewService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITestimonialService _testimonialService;

        public AdminDashboardController(ICarService carService, IBookingService bookingService, IReviewService reviewService, UserManager<AppUser> userManager, ITestimonialService testimonialService) 
        {
            _carService = carService;
            _bookingService = bookingService;
            _reviewService = reviewService;
            _userManager = userManager;
            _testimonialService = testimonialService;
        }


        public async Task<IActionResult> Index()
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

            // 4. Ortalama Araç Puanı
            var reviews = _reviewService.TGetAll();
            if (reviews.Any())
            {
                ViewBag.AverageRating = reviews.Average(x => x.Rating).ToString("0.0");
            }
            else
            {
                ViewBag.AverageRating = "Henüz Puanlama Yok";
            }

            // 5. Ortalama Kiralama Fiyatı
            var cars = _carService.TGetAll();
            if (cars.Any())
            {
                ViewBag.AvgPrice = cars.Average(x => x.Price).ToString("0.00") + " ₺";
            }
            else
            {
                ViewBag.AvgPrice = "N/A";
            }

            // 6. En Çok Talep Edilen Araç Modeli
            var bookings = _bookingService.TGetAll();
            var popularCarId = bookings
                .GroupBy(x => x.CarId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var popularCar = _carService.TGetById(popularCarId);
            ViewBag.PopularCarModel = popularCar != null ? popularCar.ModelName : "Veri Yok";

            // 7. En Çok Kullanılan Rota
            var popularRoute = bookings
                .GroupBy(x => new { x.PickupLocation, x.DropOffLocation })
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            ViewBag.PopularRoute = popularRoute != null
                ? $"{popularRoute.PickupLocation} → {popularRoute.DropOffLocation}"
                : "Veri Yok";

            // 8. Toplam Rezervasyon Sayısı
            ViewBag.BookingCount = bookings.Count();


            // 9. Müşteri Yorumları
            var testimonials = _testimonialService.TGetAll(); // Yorumları al
            ViewBag.CustomerTestimonials = testimonials;

            // Son eklenen 5 aracı alıyorum
            var last10Cars = _carService.TGetLast10Car();
            ViewBag.Last10Cars = last10Cars;


            return View();
        }
    }



}
