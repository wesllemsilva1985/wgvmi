using System.Text.RegularExpressions;

namespace wgvmi.Validations
{
    public class UserValidations
    {
        // Validação de nome de usuário
        public bool ValidateUsername(string username)
        {
            // Adicione suas regras de validação para nomes de usuário aqui
            // Por exemplo, verifique se o nome de usuário possui um comprimento mínimo e máximo
            // e se ele atende a outros requisitos, se necessário.
            // Retorne true se o nome de usuário for válido, caso contrário, retorne false.
            return !string.IsNullOrWhiteSpace(username) && username.Length >= 5 && username.Length <= 20;
        }

        // Validação de endereço de e-mail
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false; // Se o e-mail for nulo ou vazio, não é válido.
            }

            // Expressão regular para validar o formato do e-mail.
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use a classe Regex para verificar se o e-mail corresponde ao padrão.
            if (Regex.IsMatch(email, emailPattern))
            {
                return true; // Se o e-mail corresponder ao padrão, é válido.
            }

            return false; // Se não corresponder, não é válido.
        }

        // Validação de senha
        public bool ValidatePassword(string password)
        {
            // Adicione suas regras de validação para senhas aqui
            // Por exemplo, verifique se a senha atende a requisitos de comprimento mínimo,
            // contém letras maiúsculas, minúsculas e números, etc.
            // Retorne true se a senha for válida, caso contrário, retorne false.
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8;
        }
    }
}