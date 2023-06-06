using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult SendOTP()
        {
            SendActivationEmail();
            return Ok();
        }



        private void SendActivationEmail()
        {
            // gen code, update to database
            Random random = new Random();
            string rdn = (random.Next(100000,999999)).ToString();

            // end
            // send otp
            using (MailMessage mm = new MailMessage("anyakung90@gmail.com", "nguyennam0206201@gmail.com"))
            {
                mm.Subject = "Account Activation";

                mm.Body = "knh";

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("anyakung90@gmail.com", "anya1122334455");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
