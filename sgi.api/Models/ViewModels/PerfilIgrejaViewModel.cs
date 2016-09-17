using System;
using System.Collections.Generic;

namespace sgi.api.Models.ViewModels
{
    public class PerfilIgrejaViewModel
    {
        public PerfilIgrejaViewModel()
        {
            this.Endereco = new EnderecoViewModel();
        }
        public Int64 Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Facebook { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public Int64 EnderecoId { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }        
    }
}