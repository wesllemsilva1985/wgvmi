using System;
using System.Data;

public static class GlobalParameters
{
    // Propriedade estática para armazenar o total de imóveis
    public static int TotalImoveis { get; set; }

    // Parâmetros para dados gerais dos imóveis
    public static int Id { get; set; }                    // ID do imóvel
    public static DateTime DataInserido { get; set; }     // Data de inserção do imóvel
    public static string Titulo { get; set; }             // Título do imóvel
    public static string Tipo { get; set; }               // Tipo do imóvel (ex: casa, apartamento)
    public static string Cidade { get; set; }             // Cidade do imóvel
    public static string Bairro { get; set; }             // Bairro do imóvel
    public static string Estado { get; set; }             // Estado do imóvel
    public static string Endereco { get; set; }           // Endereço do imóvel
    public static string PrecoVenda { get; set; }        // Preço de venda do imóvel
    public static string Descricao { get; set; }          // Descrição do imóvel
    public static string FotoCapa { get; set; }           // Nome do arquivo da foto de capa

    // Propriedade para armazenar as fotos do imóvel como DataTable
    public static DataTable FotosImovel { get; set; }     // DataTable para armazenar as fotos do imóvel


}
