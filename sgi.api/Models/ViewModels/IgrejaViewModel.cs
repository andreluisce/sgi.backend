using System;

namespace sgi.api.Models.ViewModels
{
    public class IgrejaViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public PerfilIgrejaViewModel PerfilIgreja { get; set; }
        public DistritoViewModel Distrito { get; set; }
        public DenominacaoViewModel Denominacao { get; set; } 
    }
    
}