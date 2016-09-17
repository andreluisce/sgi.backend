using sgi.common.Resources;
using sgi.common.Validation;
using sgi.domain.Models.Enum;
using System;
using System.Collections.Generic;

namespace sgi.domain.Models
{
    public class PerfilPessoal
    {
        public Int64 Id { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Avatar { get; set; }
        public Int64? IgrejaId { get; set; }
        public Int64 EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Igreja Igreja { get; set; }
        public virtual Usuario Usuario { get; set; }

        public void Validar()
        {
            AssertionConcern.AssertArgumentBothNotEmpty(this.Fone1, this.Celular1, Errors.InvalidPhoneNumber);
            //TODO: Fazer a validação do Endereço

            /*AssertionConcern.AssertArgumentRange(this.Enderecos.Count, 1, Errors.InvalidAddress);
            foreach (var end in this.Enderecos)
            {
                end.Validar();
            }*/

        }
    }
}
