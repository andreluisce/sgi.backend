using sgi.common.Resources;
using sgi.common.Validation;
using sgi.domain.Models.Enum;
using System;
using System.Collections.Generic;

namespace sgi.domain.Models
{
    public class PerfilIgreja
    {
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
        public virtual Endereco Endereco { get; set; }
        public virtual Igreja Igreja { get; set; }       

    }
}
