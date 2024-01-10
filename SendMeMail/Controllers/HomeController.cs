using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendMeMail.Models;
using System.Net.Mail;

namespace SendMeMail.Controllers
{
    public class HomeController : Controller
    {
        private SMTPOptions _options;

        public HomeController(IOptions<SMTPOptions> opts)
        {
            _options = opts.Value;
        } 

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Send")]
        public IActionResult SendEmail([FromForm]EmailModel model)
        {
            using (var client = new SmtpClient(_options.Host, _options.Port))
            {
                var msg = new MailMessage(
                    "test_app@workshop.net",
                    model.to ?? "testuser@test.com",
                    model.subject,
                    model.body);

                client.Send(msg);
            }

            return Redirect("/");
        }
    }
}
