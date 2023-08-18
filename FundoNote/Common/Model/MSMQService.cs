using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Experimental.System.Messaging;


namespace Common.Model
{
    public class MSMQService
    {
        MessageQueue message = new MessageQueue();
        public void sendData2Queue(string token)
        {
            message.Path = @".\private$\Token";
            if (!MessageQueue.Exists(message.Path))
            {
                MessageQueue.Create(message.Path);
            }

            message.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            message.ReceiveCompleted += Message_ReceiveCompleted;
            message.Send(token);
            message.BeginReceive();
            message.Close();
           
             


        }

        private void Message_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                


                string fromEmail = "pranavtest62@gmail.com";
                string mailTitle = "Forget Password Token";
                string toEmail = "pranavtest62@gmail.com";

                MailMessage messageMade = new MailMessage(new MailAddress(fromEmail, mailTitle), new MailAddress(toEmail));


                var msg = message.EndReceive(e.AsyncResult);
                string token = msg.Body.ToString();
                string ServerURL = "https://localhost:44352/api/User/reset-password/password/confirm_password/token=" + token;
                string Subject = "Forget Password Token";
                EmailTemplate emalitemp = new EmailTemplate(ServerURL);
               
                messageMade.Subject = Subject;
                messageMade.Body = emalitemp.MakePage();
                messageMade.IsBodyHtml = true;


                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("pranavtest62@gmail.com", "iwkkfrkwkouolzrm"),
                    EnableSsl = true,

                };

                smtpClient.Send(messageMade);
                
                message.BeginReceive();
            }
            catch (Exception)
            {

                throw;
            }

        }
        
    }
}
