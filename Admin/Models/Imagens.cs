using System.IO;

namespace wgvmi.Admin.Models
{
    public class Imagens
    {

        public static void ExcluirImagem(string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                File.Delete(caminhoArquivo);
            }
        }
    }
}