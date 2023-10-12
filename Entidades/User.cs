using System;

namespace wgvmi.Entidades
{
    public class User
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nivel { get; set; }
        public string Sessao { get; set; }
        public bool Ativo { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public int TentativasLogin { get; set; }
        public string TokenResetSenha { get; set; }
    }
}