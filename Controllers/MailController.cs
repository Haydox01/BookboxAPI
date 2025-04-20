using Bookbox.Service.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }


        [HttpPost]
        [Route("SendMail")]
        public bool SendMail(MailData mailData)
        {
            return _mailService.SendMail(mailData);
        }

        [HttpPost]
        [Route("SendHTMLMail")]
        public bool SendHTMLMail(MailData htmlMailData)
        {
            return _mailService.SendHTMLMail(htmlMailData);
        }

        [HttpPost]
        [Route("SendMailWithAttachmentAsync")]
        public bool SendMailWithAttachmentAsync([FromForm] MailDataWithAttachment mailDataWithAttachment)
        {
            return _mailService.SendMailWithAttachment(mailDataWithAttachment);
        }
    }
}
