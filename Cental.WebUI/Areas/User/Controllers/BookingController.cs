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
    [Authorize(Roles = "User")]
    [Area("User")]
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
            var bookings = _bookingService.TUsersBookings(user.Id);
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }

        private List<SelectListItem> GetCarSelectedList()
        {
            return _carService.TGetAll().Select(car => new SelectListItem
            {
                Text = $"{car.Year} {car.ModelName} {car.Brand.BrandName}",
                Value = car.CarId.ToString()
            }).ToList();
        }

        public async Task<IActionResult> CreateRezervationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRezervation(InsertBookingDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var booking = _mapper.Map<Booking>(model);
            booking.UserId = user.Id;
            booking.Status = "Beklemede";
            booking.IsApproved = null;

            _bookingService.TInsert(booking);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRezervationAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;

            var booking = _bookingService.TGetById(id);
            booking.Status = booking.IsApproved switch
            {
                true => "Onaylandı",
                false => "Reddedildi",
                _ => "Beklemede"
            };

            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View(bookingDto);
        }

        [HttpPost]
        public IActionResult UpdateRezervation(UpdateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRezervation(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }

        // --- PUAN VERME ---

        [HttpGet]
        public IActionResult RateCar(int bookingId)
        {
            // bookingId ile işlemler yapılacak
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

