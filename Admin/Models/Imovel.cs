using Npgsql;

using System;
using System.Collections.Generic;
using System.Configuration;

namespace wgvmi.Admin.Models
{
    public class Imovel
    {
        public int ID { get; set; }
        public DateTime DataInserido { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string PrecoVenda { get; set; }
        public string Descricao { get; set; }
        public string FotoCapa { get; set; }

        // Lista os dados do imoveis com filtro no ID
        public static Imovel GetImovelPorID(int id)
        {
            Imovel imovel = null;

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT * FROM imoveis WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imovel = new Imovel
                            {
                                DataInserido = reader.GetDateTime(reader.GetOrdinal("datainserido")),
                                Titulo = reader.GetString(reader.GetOrdinal("titulo")),
                                Tipo = reader.GetString(reader.GetOrdinal("tipo")),
                                Cidade = reader.GetString(reader.GetOrdinal("cidade")),
                                Bairro = reader.GetString(reader.GetOrdinal("bairro")),
                                Estado = reader.GetString(reader.GetOrdinal("estado")),
                                Endereco = reader.GetString(reader.GetOrdinal("endereco")),
                                PrecoVenda = reader.GetString(reader.GetOrdinal("precovenda")),
                                Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                                FotoCapa = reader.GetString(reader.GetOrdinal("fotocapa"))
                            };
                        }
                    }
                }

                conn.Close();
            }

            return imovel;
        }

        // Recupera o registro do imovel do ultimo ID inserio
        public static int GetUltimoIDInserido()
        {
            int ultimoID = 0;

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Consulta SQL para obter o último ID inserido na tabela
                string sql = "SELECT MAX(id) FROM imoveis";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        ultimoID = Convert.ToInt32(result);
                    }
                }

                conn.Close();
            }

            return ultimoID;
        }

        // Lista todos os registros da tabela imovel
        public static List<Imovel> ListarTodosImoveis()
        {
            List<Imovel> imoveis = new List<Imovel>();

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT * FROM imoveis";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Imovel imovel = new Imovel
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")), // Inclua esta linha para obter o valor da coluna "id"
                                DataInserido = reader.GetDateTime(reader.GetOrdinal("datainserido")),
                                Titulo = reader.GetString(reader.GetOrdinal("titulo")),
                                Tipo = reader.GetString(reader.GetOrdinal("tipo")),
                                Cidade = reader.GetString(reader.GetOrdinal("cidade")),
                                Bairro = reader.GetString(reader.GetOrdinal("bairro")),
                                Estado = reader.GetString(reader.GetOrdinal("estado")),
                                Endereco = reader.GetString(reader.GetOrdinal("endereco")),
                                PrecoVenda = reader.GetString(reader.GetOrdinal("precovenda")),
                                Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                                FotoCapa = reader.GetString(reader.GetOrdinal("fotocapa"))
                            };

                            imoveis.Add(imovel);
                        }
                    }
                }

                conn.Close();
            }

            return imoveis;
        }

        // Deleta o registro do imovel pelo id
        public static void DeletarImovelPorID(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "DELETE FROM imoveis WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    }

    public class ImovelAlbum
    {
        public int Id { get; set; }
        public int ImovelId { get; set; }
        public string TituloImagem { get; set; }
        public string Imagem { get; set; }
        public DateTime DataCriacao { get; set; }

        // Função para adicionar um registro na tabela "albumimoveis"
        public static void AdicionarImagemAlbum(ImovelAlbum album)
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "INSERT INTO albumimoveis (imovelid, tituloimagem, imagem, datacriacao) " +
                             "VALUES (@imovelid, @tituloimagem, @imagem, @datacriacao)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@imovelid", album.ImovelId);
                    cmd.Parameters.AddWithValue("@tituloimagem", album.TituloImagem);
                    cmd.Parameters.AddWithValue("@imagem", album.Imagem);
                    cmd.Parameters.AddWithValue("@datacriacao", album.DataCriacao);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        // Função para buscar registros da tabela "albumimoveis" com base no ID do imóvel
        public static List<ImovelAlbum> BuscarImagensPorImovelId(int imovelId)
        {
            List<ImovelAlbum> imagens = new List<ImovelAlbum>();

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT * FROM albumimoveis WHERE imovelid = @imovelid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@imovelid", imovelId);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImovelAlbum imagem = new ImovelAlbum
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                ImovelId = reader.GetInt32(reader.GetOrdinal("imovelid")),
                                TituloImagem = reader.IsDBNull(reader.GetOrdinal("tituloimagem")) ? string.Empty : reader.GetString(reader.GetOrdinal("tituloimagem")),
                                Imagem = reader.GetString(reader.GetOrdinal("imagem")),
                                DataCriacao = reader.GetDateTime(reader.GetOrdinal("datacriacao"))
                            };

                            imagens.Add(imagem);
                        }
                    }
                }

                conn.Close();
            }

            return imagens;
        }

        public static int ContarTotalImagensPorImovelId(int imovelId)
        {
            int totalImagens = 0;

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM albumimoveis WHERE imovelid = @imovelid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@imovelid", imovelId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalImagens = Convert.ToInt32(result);
                    }
                }

                conn.Close();
            }

            return totalImagens;
        }

        public static void ExcluirRegistroPorId(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "DELETE FROM albumimoveis WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }


        public static void ExcluirImagensPorImovelId(int imovelId)
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "DELETE FROM albumimoveis WHERE imovelid = @imovelid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@imovelid", imovelId);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        // Função para exibir todos os registros da tabela "albumimoveis"
        public static List<ImovelAlbum> ExibirTodosRegistros()
        {
            List<ImovelAlbum> imagens = new List<ImovelAlbum>();

            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT * FROM albumimoveis";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImovelAlbum imagem = new ImovelAlbum
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                ImovelId = reader.GetInt32(reader.GetOrdinal("imovelid")),
                                TituloImagem = reader.IsDBNull(reader.GetOrdinal("tituloimagem")) ? string.Empty : reader.GetString(reader.GetOrdinal("tituloimagem")),
                                Imagem = reader.GetString(reader.GetOrdinal("imagem")),
                                DataCriacao = reader.GetDateTime(reader.GetOrdinal("datacriacao"))
                            };

                            imagens.Add(imagem);
                        }
                    }
                }

                conn.Close();
            }

            return imagens;
        }
    }
}
