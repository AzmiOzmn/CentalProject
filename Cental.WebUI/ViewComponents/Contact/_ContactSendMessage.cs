using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactSendMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateMessageDto());
        }
    }
}
