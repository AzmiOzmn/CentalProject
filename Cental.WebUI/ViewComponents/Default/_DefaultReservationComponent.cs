using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Security.Claims;

public class _DefaultReservationComponent : ViewComponent
{
    private readonly IBookingService _bookingService;
    private readonly IBannerService _bannerService;
    private readonly ICarService _carService;

    public _DefaultReservationComponent(IBookingService bookingService, ICarService carService, IBannerService bannerService)
    {
        _bookingService = bookingService;
        _carService = carService;
        _bannerService = bannerService;
    }

    public IViewComponentResult Invoke(Booking model = null)
    {
        model ??= new Booking();

        var selectCarList = _carService.TGetAll()
            .Select(car => new SelectListItem
            {
                Text = car.Brand?.BrandName + " " + car.ModelName,
                Value = car.CarId.ToString()
            })
            .ToList();

        ViewBag.CarList = selectCarList ?? new List<SelectListItem>();

        // 🔥 Kullanıcı bilgisi burada doğru şekilde alınır:
        var user = ViewContext?.HttpContext?.User;
        ViewBag.IsUserAuthenticated = user?.Identity?.IsAuthenticated ?? false;

        return View(model);
    }
}
