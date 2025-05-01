using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
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
        private readonly IMapper _mapper;

        public BookingController(UserManager<AppUser> userManager, IBookingService bookingService, ICarService carService, IMapper mapper)
        {
            _userManager = userManager;
            _bookingService = bookingService;
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var bookings = _bookingService.TUsersBookings(user.Id);  // Giriş yapan kullanıcıya ait rezervasyonlar
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }


        private List<SelectListItem> GetCarSelectedList()
        {
            var selectedCarList = (from car in _carService.TGetAll()
                                   select new SelectListItem
                                   {
                                       Text = car.Year + " " + car.ModelName + " " + car.Brand.BrandName,
                                       Value = car.CarId.ToString()
                                   }).ToList();
            return selectedCarList;
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);  // Giriş yapan kullanıcıyı alıyoruz.

            var booking = _mapper.Map<Booking>(model);
            booking.UserId = user.Id; // Kullanıcı ID'sini doğru bir şekilde atıyoruz.
            booking.Status = "Beklemede";
            booking.IsApproved = null;

            _bookingService.TInsert(booking);  // Rezervasyonu kaydediyoruz.
            return RedirectToAction("Index");  // Kullanıcıyı rezervasyonlar sayfasına yönlendiriyoruz.
        }


        public async Task<IActionResult> UpdateRezervationAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            var booking = _bookingService.TGetById(id);
            if (booking.IsApproved == true)
            {
                booking.Status = "Onaylandı";
            }
            else if (booking.IsApproved == false)
            {
                booking.Status = "Reddedildi";
            }
            else
            {
                booking.Status = "Beklemede";
            }
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
    }
}
