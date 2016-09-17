using System;

namespace sgi.api.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }
        public PerfilPessoalViewModel PerfilPessoal { get; set; } 
    }

}