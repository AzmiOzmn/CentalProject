using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminMessageController(IMessageService messageService, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = messageService.TGetAll().Where(x => !x.IsRead).ToList();
            var dto = mapper.Map<List<ResultMessageDto>>(values);
            return View(dto);
        }

        public IActionResult ReadMessages()
        {
            var values = messageService.TGetAll().Where(x => x.IsRead).ToList();
            var dto = mapper.Map<List<ResultMessageDto>>(values);
            return View(dto);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = messageService.TGetById(id);
            message.IsRead = true;
            messageService.TUpdate(message);
            var dto = mapper.Map<ResultMessageDto>(message);
            return View(dto);
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = messageService.TGetById(id);
            messageService.TDelete(id);
            return RedirectToAction("Index");
        }
    }

}
