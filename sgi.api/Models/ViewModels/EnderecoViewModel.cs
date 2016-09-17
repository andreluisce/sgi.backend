using sgi.domain.Models.Enum;
using System;

namespace sgi.api.Models.ViewModels
{
    public class EnderecoViewModel
    {
        public Int64 Id { get; set; }
        public string Numero { get; set; }
        public string EnderecoNome { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public Int64 CidadeId { get; set; }        
        public CidadeViewModel Cidade { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
    }
}