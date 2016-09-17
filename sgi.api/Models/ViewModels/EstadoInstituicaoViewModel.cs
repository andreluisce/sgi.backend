using sgi.domain.Models;
using System;

namespace sgi.api.Models.ViewModels
{
    public class EstadoInstituicaoViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}