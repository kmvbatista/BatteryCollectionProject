using AspCore_Email.Models;
using DataTypeObject.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost]
        public IActionResult EnviaEmail([FromBody]EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem ).GetAwaiter();
                    return Accepted();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}