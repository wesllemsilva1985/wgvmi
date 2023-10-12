using System;
using System.Net.Mail;

namespace wgvmi
{
    public partial class mail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string nomeRemetente = "Remetente";

            string emailRemetente = "suporte@wgvmi.com.br";
            string assuntoMensagem = "ee";
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();
            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");


            objEmail.To.Add("wesllem.silva2@gmail.com");


            objEmail.Priority = System.Net.Mail.MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assuntoMensagem;
            objEmail.Body = "eeeeee";
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            objSmtp.Host = "smtp.wgvmi.com.br";
            objSmtp.UseDefaultCredentials = false;
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, "Wesllem@07032010");
            objSmtp.Port = 587;

            try
            {

                objSmtp.Send(objEmail);
                StatusLabel.Text = "Sucesso";
            }
            catch (SmtpException smtpEx)
            {
                // Você pode acessar informações detalhadas sobre o erro aqui
                string errorMessage = "Erro ao enviar o e-mail: " + smtpEx.Message + "--" + smtpEx.StatusCode.ToString(); ;
                int errorCode = (int)smtpEx.StatusCode; // Código de status SMTP
                StatusLabel.Text = errorMessage;
            }
            finally
            {
                objEmail.Dispose();
            }
        }
    }
}