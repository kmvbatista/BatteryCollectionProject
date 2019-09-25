using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System.Net.Mail;
using DataTypeObject.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace BusinessLogicalLayer
{
    public class FeatureHintBLL : IFEATURE
    {
        public FeatureHintBLL(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public EmailSettings _emailSettings { get; }
        public void SendEmail(FeatureHint feature) {
            MailMessage mail = GetMailMessage();
            mail.Body = GetMailBody(feature);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail,_emailSettings.UsernamePassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

        private string GetMailBody(FeatureHint feature)
        {
            return $@"Usuario {feature.Sender.Name}, portador do email {feature.Sender.Email}
                solicitou cadastro de {feature.Local}, com a seguinte descrição: {feature.Description} ";
        }

        private MailMessage GetMailMessage() 
        {      
            string toEmail =  _emailSettings.ToEmail; 
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.UsernameEmail, "Jose Carlos Macoratti")
            };
            mail.To.Add(new MailAddress(toEmail));
            mail.CC.Add(new MailAddress(_emailSettings.CcEmail));
            mail.Subject = "Cadastro do email";
            return mail;
        }
  }
}
