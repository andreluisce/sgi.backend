using System;
using System.Collections.Generic;

namespace sgi.api.Models.ViewModels
{
    public class PerfilPessoalViewModel
    {
        public Int64 Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public sgi.domain.Models.Enum.Sexo Sexo { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Avatar { get; set; }
        public Int64 EnderecoId { get; set; }
        public Int64 IgrejaId { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
        public virtual IgrejaViewModel Igreja { get; set; }  
    }
}