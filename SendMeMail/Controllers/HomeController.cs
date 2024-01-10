using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendMeMail.Models;
using System.Net.Mail;

namespace SendMeMail.Controllers
{
    /// <summary>
    /// A simple controller that contains all the actions needed for the demo.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// These are per-environment configuration settings for the STMP server.
        /// </summary>
        private SMTPOptions _options;

        public HomeController(
            IOptions<SMTPOptions> opts)
        {
            _options = opts.Value;
        } 

        /// <summary>
        /// By convention, this returns the Home HTML view.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// A post to this action from the Home view will parse the form values, send 
        /// an email using them, and redirect the browser back to the Home view.
        /// </summary>
        [HttpPost]
        [Route("Send")]
        public IActionResult SendEmail(
            [FromForm]
            EmailModel model)
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
