using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class BookingController(IBookingService _bookingService, ICarService _carService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var bookings = _bookingService.TGetAll();
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
        public IActionResult CreateRezervation()
        {
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateRezervation(InsertBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.Status = "Beklemede";
            booking.IsApproved = null;
            _bookingService.TInsert(booking);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View(bookingDto);
        }
        [HttpPost]
        public IActionResult UpdateRezervation(UpdateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
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
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRezervation(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApproveRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = true;
            booking.Status = "Onaylandı";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = false;
            booking.Status = "Reddedildi";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult WaitingRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = null;
            booking.Status = "Beklemede";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }
    }
}
