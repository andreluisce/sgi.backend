using System;

namespace sgi.api.Models.ViewModels
{
    public class IgrejaInstituicaoViewModel
     {
        public IgrejaInstituicaoViewModel()
        {
            this.PerfilIgreja = new PerfilIgrejaViewModel();            
        }
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public long DistritoId { get; set; }
        public virtual PerfilIgrejaViewModel PerfilIgreja { get; set; }
    }
}