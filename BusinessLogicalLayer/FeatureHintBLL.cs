using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System.Net.Mail;
using DataTypeObject.Interfaces;

namespace BusinessLogicalLayer
{
    public class FeatureHintBLL : IFEATURE
    {
        public FeatureHintBLL()
        {
            
        }
        public void SendEmail(FeatureHint feature) {
            MailMessage mail = GetMailMessage(feature, new MailMessage());
            mail.Body = GetMailBody(feature.Material ?? feature.Local, feature);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Send(mail);
            mail = null;
        }

        private string GetMailBody(string Subject, FeatureHint feature)
        {
            return $@"Usuario {feature.Sender.Name}, portador do email {feature.Sender.Email}
                solicitou cadastro de {feature.Local}, com a seguinte descrição: {feature.Description} ";
        }

    private MailMessage GetMailMessage(FeatureHint feature, MailMessage mail) 
    {       
        mail.From = new MailAddress("kennedymessias.vb@gmail.com");
        mail.To.Add("kennedymnovas@gmail.com");
        mail.Subject = "Cadastro do email";
        return mail;
    }
  }
}
