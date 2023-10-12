using System;
using System.Net;
using System.Net.Mail;

public class SmtpConnectionChecker
{
    public static string CheckSmtpConnection(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword, string destinatario, string assunto, string body)
    {
        try
        {
            // Cria um objeto SmtpClient para enviar o email
            using (SmtpClient smtpClient = new SmtpClient(smtpHost))
            {
                // Define a porta SMTP e as credenciais do servidor
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = false; // Define como 'true' se o servidor SMTP usar SSL/TLS

                // Cria um objeto MailMessage para representar o email
                MailMessage objEmail = new MailMessage();

                // Define o endereço de email do remetente
                objEmail.From = new MailAddress("suporte@wgvmi.com.br");

                // Adiciona o destinatário (pode ser mais de um, usando objEmail.To.Add())
                objEmail.To.Add(destinatario);

                // Define o assunto e o corpo do email
                objEmail.Subject = assunto;
                objEmail.IsBodyHtml = true;
                objEmail.Body = body;


                // Tenta se conectar ao servidor SMTP e enviar o email
                smtpClient.Send(objEmail);
            }

            return "E-mail enviado com sucesso!";
        }
        catch (SmtpException smtpEx)
        {
            // Captura erros específicos do SMTP (por exemplo, problemas de autenticação ou envio)
            return "Erro na conexão com o servidor SMTP: " + smtpEx.Message;
        }
        catch (Exception ex)
        {
            // Captura erros gerais que podem ocorrer durante o processo
            return "Erro inesperado: " + ex.Message;
        }
    }
}
