using System;

using wgvmi.Models;
using wgvmi.Validations;

using static wgvmi.Account.Usuario;

namespace wgvmi.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlRecoverPassword.Visible = false;
                mailSucesso.Visible = false;
            }
        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Email = txtRecoveryEmail.Text,
                Password = txtSenha.Text
            };

            if (string.IsNullOrEmpty(user.Email))
            {
                RecoveryLabel.Text = "Informe o email";
            }
            else
            {
                UserValidations userValidations = new UserValidations(); // Crie uma instância da classe

                bool emailValido = userValidations.ValidateEmail(user.Email); // Chame a função com o e-mail

                if (emailValido)
                {
                    //Passando as validações anteriores, vai para função para buscar o email no banco
                    buscaSenhaPorEmail(user.Email);
                }
                else
                {
                    // O e-mail não é válido
                }
            }
        }

        protected void lnkRecPass_Click(object sender, EventArgs e)
        {
            RecoveryLabel.Text = "";
            loginContainer.Visible = false;
            pnlRecoverPassword.Visible = true;
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            // Quando o link "Cancelar" é clicado, você pode mostrar novamente o painel de login e ocultar o de recuperação
            loginContainer.Visible = true;
            pnlRecoverPassword.Visible = false;
            RecoveryLabel.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Email = txtRecoveryEmail.Text,
                Username = txtUsuario.Text,
                Password = txtSenha.Text
            };

            // Verifique se as strings são nulas ou vazias
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                // Trate o caso em que usuário ou senha são nulos ou vazios
                // Por exemplo, exiba uma mensagem de erro para o usuário.
                ErrorMessageLabel.Text = "Usuário e senha são obrigatórios.!";
            }
            else
            {
                UserValidations userValidations = new UserValidations(); // Crie uma instância da classe

                bool emailValido = userValidations.ValidateEmail(user.Username); // Chame a função com o e-mail

                if (emailValido)
                {
                    // Chama a função para buscar no banco pelo email
                    validaNomeUser(user.Username, user.Password);
                }
                else
                {
                    // O e-mail não é válido
                    validaNomeUser(user.Username, user.Password);
                }
            }
        }

        protected void validaNomeUser(string usuario, string senha)
        {
            DadosUsuario dadosUsuario = Usuario.LerUsuariosDaView(usuario);
            string senhaConf = dadosUsuario.Senha;

            if (!string.IsNullOrEmpty(dadosUsuario.NomeUsuario))

            {
                // apos o usuario ser encontrado no banco Verifica se a senha digitada é a mesma cadastrada
                if (senhaConf == senha)
                {
                    ErrorMessageLabel.Text = "Ok!";
                }
                else
                {
                    // senha invalida
                    ErrorMessageLabel.Text = "Senha inválida!";
                }
            }
            else
            {
                // Nenhum dado foi encontrado, trate esse caso.
                ErrorMessageLabel.Text = "Usuário não cadastrado!";
            }
        }

        //Função para verificar o email cadastrado no banco
        protected void buscaSenhaPorEmail(string usuario)
        {
            DadosUsuario dadosUsuario = Usuario.LerUsuariosDaView(usuario);

            if (!string.IsNullOrEmpty(dadosUsuario.NomeUsuario))
            {
                string senha = dadosUsuario.Senha;
                string nomeUsu = dadosUsuario.NomeUsuario;
                DateTime dataAgora = DateTime.Now;
                string dataFormat = dataAgora.ToString("dd/MM/yyyy HH:mm:ss");

                // Suponha que você tenha o ID do usuário e o novo token
                string email = dadosUsuario.Email; // Substitua pelo ID correto do usuário

                string novoToken = GerarToken(20); // Gera um token com 20 caracteres

                bool atualizacaoBemSucedida = AtualizarTokenRedefinicaoSenha(email, novoToken);

                string smtpHost = "smtp.wgvmi.com.br";
                int smtpPort = 587;
                string smtpUsername = "suporte@wgvmi.com.br";
                string smtpPassword = "Wesllem@07032010";
                string bodyFormatted = "<html><body>" +
      "<div class='email-container' style='width: 70%; margin: 0 auto; border: 1px solid #e0e0e0; border-radius: 5px; box-shadow: 0 0 10px #87ceeb;'>" +
      "<div class='header' style='background-color: #87ceeb; padding: 10px; text-align: center; color: #fff;'>" +
      "<h1>Redefinição de senha - Painel administrativo WGVMI</h1>" +
      "</div>" +
      "<div class='content' style='padding: 20px;'>" +
      "<p>Olá " + nomeUsu + ",</p>" +
      "<p>Você solicitou a redefinição de senha no Painel Administrativo da WGVMI.</p>" +
      "<p>Data de Solicitação: " + dataFormat + "</p>" +
      "<p>Para redefinir sua senha, clique no link abaixo:</p>" +
      "<p><a href='[Link de Redefinição de Senha]'>Redefinir Senha</a></p>" +
      "<p>Se você não solicitou a redefinição de senha, ignore este email.</p>" +
      "</div>" +
      "<div class='footer' style='background-color: #87ceeb; padding: 10px; text-align: center; color: #fff;'>" +
      "<p>&copy; 2023 WGVMI. Todos os direitos reservados.</p>" +
      "<p><a href='https://www.wgvmi.com.br'>WGVMI</a></p>" +
      "<img src='http://wgvmi.com.br/Content/themes/ByWescomp/images/wgvmi_logoI.png' alt='Logo WGVMI' width='200' height='200'>" +
      "</div>" +
      "</div>" +
      "</body></html>";

                string result = SmtpConnectionChecker.CheckSmtpConnection(smtpHost, smtpPort, smtpUsername, smtpPassword, dadosUsuario.Email, "Redefinição de senha - Painel de controle WGVMI", bodyFormatted);
                pnlRecoverPassword.Visible = false;
                mailSucesso.Visible = true;
                msdMailSucesso.Text = result + " para: " + dadosUsuario.Email + "<br>"
                    + "O link para redefinição da sua senha foi enviado para seu email.<br><br>"
                    + "Você pode fechar essa pagina.";
            }
            else
            {
                // Nenhum dado foi encontrado, trate esse caso.
                RecoveryLabel.Text = "Email nao registrado";
            }
        }
    }
}