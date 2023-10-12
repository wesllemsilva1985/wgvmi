using System.Globalization;
using System.Text.RegularExpressions;

namespace wgvmi.Admin.Models
{
    public class Validacoes
    {
        // Método para validar o campo "Título".
        public static bool ValidarTitulo(string titulo)
        {
            // Verifica se o campo não está em branco e se tem pelo menos 5 caracteres.
            return !string.IsNullOrWhiteSpace(titulo) && titulo.Length >= 5;
        }

        // Método para validar o campo "Cidade".
        public static bool ValidarCidade(string cidade)
        {
            // Verifica se o campo não está em branco, se tem pelo menos 5 caracteres e no máximo 20 caracteres.
            return !string.IsNullOrWhiteSpace(cidade) && cidade.Length >= 5 && cidade.Length <= 20;
        }

        // Método para validar o campo "Bairro".
        public static bool ValidarBairro(string bairro)
        {
            // Verifica se o campo não está em branco, se tem pelo menos 5 caracteres e no máximo 20 caracteres.
            return !string.IsNullOrWhiteSpace(bairro) && bairro.Length >= 5 && bairro.Length <= 20;
        }

        // Método para validar o campo "Estado".
        public static bool ValidarEstado(string estado)
        {
            // Verifica se o campo não está em branco, se tem pelo menos 5 caracteres e no máximo 20 caracteres.
            return !string.IsNullOrWhiteSpace(estado) && estado.Length >= 5 && estado.Length <= 20;
        }

        // Método para validar o campo "Endereço".
        public static bool ValidarEndereco(string endereco)
        {
            // Verifica se o campo não está em branco, se tem pelo menos 5 caracteres e no máximo 50 caracteres.
            return !string.IsNullOrWhiteSpace(endereco) && endereco.Length >= 5 && endereco.Length <= 50;
        }

        // Método para validar o campo "Preço de Venda" como moeda brasileira.
        public static bool ValidarPrecoVenda(string precoVenda)
        {
            // Remove qualquer formatação de moeda existente (exceto dígitos e vírgulas).
            string preco = Regex.Replace(precoVenda, @"[^\d,]", "");

            // Tenta analisar o valor como um decimal usando o formato de moeda brasileira.
            decimal precoDecimal;
            return decimal.TryParse(preco, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out precoDecimal);
        }
    }
}
