using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository;

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
        [Route("sendOTP")]
        [HttpPost]
        public IActionResult SendOTP(string email)
        {
            SendActivationEmail(email);
            return Ok();
        }
        [Route("tryOTP")]
        [HttpPost]
        public IActionResult CheckOTP(string email,string otp)
        {
            ActiveCodeRepositoryImp repo = new ActiveCodeRepositoryImp();
            string code = repo.GetActiveCode(email);
            if(code != null && code.Equals(otp))
            {
                return Ok();
            }
            return Unauthorized();
        }



        private void SendActivationEmail(string email)
        {
            // gen code, update to database
            Random random = new Random();
            string rdn = "";
            for(int i = 0; i < 6; i++)
            {
                rdn += (random.Next(0,9)).ToString();
            }
            ActiveCodeRepositoryImp repo = new ActiveCodeRepositoryImp();
            repo.CreateActiveCode(email, rdn);

            // end
            // send otp
            using (MailMessage mm = new MailMessage("efoodcompanyservice@gmail.com", email))
            {
                mm.Subject = "Active Code";

                mm.Body = "Your active code is: " + rdn;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("efoodcompanyservice@gmail.com", "ihyxaxrsytxnwcbo");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
