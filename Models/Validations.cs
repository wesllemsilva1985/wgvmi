using System;
using System.Text.RegularExpressions;

namespace wgvmi.Models
{
    public class Validations
    {
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Use uma expressão regular para verificar o formato do e-mail
                string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-z]{2,})$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                // Em caso de erro na validação, retorne false
                return false;
            }
        }

    }

}