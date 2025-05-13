using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BookingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public BookingController(
            UserManager<AppUser> userManager,
            IBookingService bookingService,
            ICarService carService,
            IReviewService reviewService,
            IMapper mapper)
        {
            _userManager = userManager;
            _bookingService = bookingService;
            _carService = carService;
            _reviewService = reviewService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var bookings = _bookingService.TUsersBookings(user.Id); // Kullanıcının sadece kendi rezervasyonlarını alıyoruz.
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }

        // Puan verme sayfası
        [HttpGet]
        public IActionResult RateCar(int bookingId)
        {
            var booking = _bookingService.TGetById(bookingId);
            if (booking == null || booking.IsApproved != true)
            {
                return NotFound();
            }

            var dto = new InsertReviewDto
            {
                CarId = booking.CarId
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult RateCar(InsertReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var review = _mapper.Map<Review>(dto);
            _reviewService.TInsert(review);

            return RedirectToAction("Index");
        }
    }
}
