using System.Net;
using System.Net.Mail;

public class EmailSender
{
    public string SendEmail(string toAddress, string subject, string body)
    {
        // Configure as informações do servidor SMTP
        SmtpClient smtpClient = new SmtpClient("email-ssl.com.br");
        smtpClient.Port = 465; // Use a porta SMTP correta
        smtpClient.Credentials = new NetworkCredential("suporte@wgvmi.com.br", "Wesllem@07032010"); // Substitua pelo seu email e senha
        smtpClient.EnableSsl = true; // Habilita SSL/TLS para segurança

        // Crie um objeto MailMessage
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("suporte@wgvmi.com.br"); // Seu endereço de e-mail
        mailMessage.To.Add(toAddress); // O destinatário
        mailMessage.Subject = subject; // Assunto do e-mail
        mailMessage.Body = body; // Corpo do e-mail

        try
        {
            // Envie o e-mail
            smtpClient.Send(mailMessage);
            return "E-mail enviado com sucesso.";
        }
        catch (SmtpException smtpEx)
        {
            // Você pode acessar informações detalhadas sobre o erro aqui
            string errorMessage = "Erro ao enviar o e-mail: " + smtpEx.Message + "--" + smtpEx.StatusCode.ToString(); ;
            int errorCode = (int)smtpEx.StatusCode; // Código de status SMTP
            string errorDescription = smtpEx.StatusCode.ToString(); // Descrição do código de status

            // Faça o que for necessário com as informações de erro
            return errorMessage;
        }
        finally
        {
            // Libere recursos
            smtpClient.Dispose();
            mailMessage.Dispose();
        }
    }
}