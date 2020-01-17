using System;
using System.Net;
using System.Net.Mail;

namespace teste
{
  class Program
  {
    static void Main(string[] args)
    {
      MailMessage mail = new MailMessage();

      var origin = "powershellesquema2@gmail.com";
      var pass = "jo@oVitor123";

      mail.From = new MailAddress(origin);
      mail.To.Add("joaorabello99@gmail.com"); // para
      mail.Subject = "Aviso urgente - Instabilidade Protocolo"; // assunto
      mail.Body = $"E-mail automático de aviso. Às {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} foi realizado uma requisão com falha."; // mensagem

      using (var smtp = new SmtpClient("smtp.gmail.com"))
      {
        smtp.EnableSsl = true; // GMail requer SSL
        smtp.Port = 587;       // porta para SSL
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
        smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas


        // seu usuário e senha para autenticação
        smtp.Credentials = new NetworkCredential(origin, pass);


        try
        {
          smtp.Send(mail);
        }
        catch (Exception ex)
        {
          var erro = ex;
        }
        // envia o e-mail
      }

    }
  }
}