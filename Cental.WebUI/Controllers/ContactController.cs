using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly CentalContext _context;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public ContactController(CentalContext context, IMessageService messageService, IMapper mapper)
        {
            _context = context;
            _messageService = messageService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<Message>(model);
                _messageService.TInsert(message);
                return RedirectToAction("Index", "Contact");
            }
            return View(model);
        }
    }
}
