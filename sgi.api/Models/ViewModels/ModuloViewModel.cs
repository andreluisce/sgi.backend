using System.Collections.Generic;

namespace sgi.api.Models.ViewModels
{
    public class ModuloViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CssClass { get; set; }
        //public Int64? SupermoduloId { get; set; }
        public virtual ICollection<AcaoViewModel> Acoes { get; set; }      
        public virtual ICollection<SubModuloViewModel> Submodulos { get; set; }        
          
    }
}